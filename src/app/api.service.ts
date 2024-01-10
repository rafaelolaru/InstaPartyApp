import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiEndpoint = '/api'; // Root endpoint for backend API

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiEndpoint}/Auth/login`, { username, password });
  }

   register(userData: any): Observable<any> {
    return this.http.post<any>(`${this.apiEndpoint}/Auth/register`, userData);
  }

  createNewParty(partyData: any): Observable<any> {
    return this.http.post<any>(`${this.apiEndpoint}/Subs/CreateNewParty`, partyData);
  }

  subToParty(partyId: number): Observable<any> {
    return this.http.post<any>(`${this.apiEndpoint}/Subs/SubToParty/${partyId}`, {});
  }

  getAllParties(): Observable<any> {
    return this.http.get<any>(`${this.apiEndpoint}/Subs/GetAllParties`);
  }

  deleteFromMyParties(partyId: number): Observable<any> {
    return this.http.delete<any>(`${this.apiEndpoint}/Subs/deleteFromMyParties/${partyId}`);
  }

  getMyParties(): Observable<any> {
    return this.http.get<any>(`${this.apiEndpoint}/Subs/GetMyParties`);
  }
}
