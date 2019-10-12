import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanLoad {
  
  path: import("@angular/router").ActivatedRouteSnapshot[];
  route: import("@angular/router").ActivatedRouteSnapshot;
  
  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  canActivate() {
    return this.canLoad();
  }
  canLoad() {
    if (!this.authService.existToken()) {
      this.router.navigate(['auth']);
    }
    return this.authService.existToken();
  }
}
