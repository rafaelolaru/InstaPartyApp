import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiEndpoint = '/api'; // Root endpoint for backend API
  private baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    // return this.http.post<any>(${this.apiEndpoint}/Auth/login, { username, password });
    return this.http.post<any>(`${this.baseUrl}/Auth/login`, { username, password });
  }

   register(userData: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Auth/register`, userData);
  }

  createNewParty(partyData: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Subs/CreateNewParty`, partyData);
  }

  subToParty(partyId: number): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Subs/SubToParty/${partyId}`, {});
  }

  getAllParties(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/Subs/GetAllParties`);
  }

  deleteFromMyParties(partyId: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/Subs/deleteFromMyParties/${partyId}`);
  }

  getMyParties(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/Subs/GetMyParties`);
  }
}