import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { tap, mapTo, catchError } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiAuth: string = `${environment.api}/User`;
  private readonly JWT_TOKEN = 'jwt_token';
  private isLoginSubject = new BehaviorSubject<boolean>(this.existToken());

  constructor(private httService: HttpClient) { }

  login(credentials): Observable<boolean> {
    return this.httService.post(`${this.apiAuth}/Authenticate`, credentials)
      .pipe(
        tap(data => this.doLogin(data)),
        mapTo(true),
        catchError(error => {
          return of(false);
        })
      );
  }
  logout() {
    this.doLogout();
  }
  isLoggedIn(): Observable<boolean> {
    return this.isLoginSubject.asObservable();
  }

  existToken(): boolean {
    const helper = new JwtHelperService();
    let token = this.getToken();
    const isExpired = helper.isTokenExpired(token);
    return !isExpired;
  }
  getToken(): string {
    return localStorage.getItem(this.JWT_TOKEN);
  }
  private doLogin(loginResponse) {
    this.storeToken(loginResponse.token);
    this.isLoginSubject.next(true);
  }

  private doLogout() {
    this.removeToken();
    this.isLoginSubject.next(false);
  }

  private storeToken(token: string) {
    localStorage.setItem(this.JWT_TOKEN, token);
  }
  private removeToken() {
    localStorage.removeItem(this.JWT_TOKEN);
  }
}
