import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
@Injectable()
export class AuthService{

    private _registerUrl = "http://localhost:7188/Auth/register";
    private _loginUrl = "http://localhost:7188/Auth/login";

    constructor(private http:HttpClient){}
    registerUser(user: any){
        return this.http.post<any>(this._registerUrl, user)
    }

    loginUser(user: any){
        return this.http.post<any>(this._loginUrl, user)
    }
}