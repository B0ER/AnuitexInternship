import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate } from '@angular/router';
import { AuthenticationService } from './authentication/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private router: Router, private authService: AuthenticationService) { }


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let allowRoles = route.data.allowRoles;
    const currentUserJwt = this.authService.currentUserJwtValue;
    if (currentUserJwt && this.authService.isAuthorized(allowRoles)) {
      return true;
    }

    this.router.navigate(['/account/sign-in'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
