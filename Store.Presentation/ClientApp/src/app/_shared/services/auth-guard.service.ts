import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from './authentication/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

  constructor(private router: Router, private authService: AuthenticationService) { }

  activeFor(role: string) {
    let self = this;
    return {
      canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUserJwt = self.authService.currentUserJwtValue;
        if (currentUserJwt && currentUserJwt.roles.includes(role)) {
          // authorised so return true
          return true;
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/account/sign-in'], { queryParams: { returnUrl: state.url } });
        return false;
      }
    }
  }
}
