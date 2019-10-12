import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form = new FormGroup({
    username: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  })
  constructor(
    private _service: AuthService, 
    private router: Router
    ) { }

  ngOnInit() {
    if(this._service.existToken()) this.router.navigate(['administration', 'workloads'])
  }

  login(){
    let model = this.form.value
    this._service.login(model).subscribe((res)=>{
      if(res){
        this.router.navigate(['administration', 'workloads'])
        window.location.reload()
      }
    });
    
  }

}
