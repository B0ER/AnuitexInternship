import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest, HttpResponse, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { JwtReponse } from "../models/account/JwtResponse";
import { AuthenticationService } from "../services/authentication/authentication.service";

@Injectable({
  providedIn: 'root'
})
export class ApiInterceptor implements HttpInterceptor {
  private jwtAuthModel: JwtReponse;

  constructor(private authService: AuthenticationService) {
    this.authService.currentJwtSubject.subscribe(jwt => this.jwtAuthModel = jwt);
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.jwtAuthModel)
      req = req.clone({ setHeaders: { 'Authorization': `Bearer ${this.jwtAuthModel.accessToken}` } });

    return next.handle(req).pipe(
      tap(
        event => {
          if (event instanceof HttpResponse) {
            console.log(event.body);
            console.log('Server response');
          }
        },
        err => {
          console.log(err);
          if (err instanceof HttpErrorResponse) {
            if (err.status == 401) {
              if (this.jwtAuthModel)
                this.authService.refreshToken(this.jwtAuthModel.refreshToken);
            }

            if (err.status == 500)
              console.log('Server Error');
          }
        }));
  }
}
