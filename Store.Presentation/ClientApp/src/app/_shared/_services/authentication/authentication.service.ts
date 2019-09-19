import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { JwtReponse } from '../../_models/JwtResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private currentJwtSubject: BehaviorSubject<JwtReponse>;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.currentJwtSubject = new BehaviorSubject<JwtReponse>(JSON.parse(localStorage.getItem('jwt')));
  }

  public get currentUserJwtValue(): JwtReponse {
    return this.currentJwtSubject.value;
  }

  public get AuthorizeBearerHeader(): HttpHeaders {
    let header = new HttpHeaders({ 'Authorization': `Bearer ${this.currentJwtSubject.value.accessToken}` });
    return header;
  }

  login(Email: string, Password: string, RememberMe: boolean = false) {
    return this.httpClient.post<JwtReponse>(`${this.baseUrl}/account/sign-in`, { Email, Password, RememberMe })
      .pipe(map(jwt => {
        localStorage.setItem('jwt', JSON.stringify(jwt));
        this.currentJwtSubject.next(jwt);
        return jwt;
      }));
  }

  register(Email: string, Password: string, PasswordRepeat: string) {
    return this.httpClient.post(`${this.baseUrl}/account/sign-up`, { Email, Password, PasswordRepeat });
  }

  logout() {
    localStorage.removeItem('jwt');
    let jwtSignOutObservable = this.httpClient.post(
      `${this.baseUrl}/account/sign-out`,
      {},
      { headers: { 'Authorization': `Bearer ${this.currentJwtSubject.value.accessToken}` } }
    )
    this.currentJwtSubject.next(null);
    return jwtSignOutObservable;
  }
}
