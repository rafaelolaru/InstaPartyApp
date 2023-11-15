import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  loginUserData = {}
  //constructor(private _auth:AuthService){}

  ngOnInit(): void {
    
  }
  // loginUser(){
  //   this._auth.loginUser(this.loginUserData)
  //   .subscribe(
  //     res => console.log(res),
  //     err => console.log(err)
  //   )
  // }
}
