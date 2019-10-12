import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Web';
  isLoggedIn: Observable<boolean>;

  fecha = (new Date()).getFullYear()

  constructor(private _service: AuthService){

  }

  ngOnInit(): void {
    this.isLoggedIn = this._service.isLoggedIn();
  }
}
