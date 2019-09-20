import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { JwtReponse } from '../../models/account/JwtResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _currentJwtSubject: BehaviorSubject<JwtReponse>;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this._currentJwtSubject = new BehaviorSubject<JwtReponse>(JSON.parse(localStorage.getItem('jwt')));
  }

  public get currentJwtSubject(): BehaviorSubject<JwtReponse> {
    return this._currentJwtSubject;
  }
  public get currentUserJwtValue(): JwtReponse {
    return this._currentJwtSubject.value;
  }

  public get AuthorizeBearerHeader(): HttpHeaders {
    let header = new HttpHeaders({ 'Authorization': `Bearer ${this._currentJwtSubject.value.accessToken}` });
    return header;
  }

  login(Email: string, Password: string, RememberMe: boolean = false): Observable<JwtReponse> {
    //todo: rememberMe == false => don't save in local storage
    return this.httpClient.post<JwtReponse>(`${this.baseUrl}api/account/sign-in`, { Email, Password, RememberMe })
      .pipe(map(jwt => {
        localStorage.setItem('jwt', JSON.stringify(jwt));
        this._currentJwtSubject.next(jwt);
        return jwt;
      }));
  }

  register(Email: string, Password: string, PasswordRepeat: string): Observable<Object> {
    return this.httpClient.post(`${this.baseUrl}api/account/sign-up`, { Email, Password, PasswordRepeat });
  }

  refreshToken(RefreshToken: string): Observable<JwtReponse> {
    return this.httpClient.post<JwtReponse>(`${this.baseUrl}api/account/refresh-token`, { RefreshToken })
      .pipe(map(jwt => {
        this.currentJwtSubject.next(jwt);
        return jwt;
      }));
  }

  logout(): Observable<Object> {
    localStorage.removeItem('jwt');
    let jwtSignOutObservable = this.httpClient.post(
      `${this.baseUrl}api/account/sign-out`,
      {},
      { headers: { 'Authorization': `Bearer ${this._currentJwtSubject.value.accessToken}` } }
    )
    this._currentJwtSubject.next(null);
    return jwtSignOutObservable;
  }

  isAuthorized(allowedRoles: string[]): boolean {
    if (allowedRoles == null || allowedRoles.length === 0) {
      return true;
    }

    const roles = this.currentJwtSubject.value.roles;
    return allowedRoles.some(r => roles.includes(r));
  }
}
