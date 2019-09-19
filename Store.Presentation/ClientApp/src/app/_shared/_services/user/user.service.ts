import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll(headers: HttpHeaders) {
    return this.httpClient.get(`${this.baseUrl}/user/`, { headers });
  }

  findById(id: string, headers: HttpHeaders) {
    return this.httpClient.get(`${this.baseUrl}/user/${id}`, { headers });
  }

  create(headers: HttpHeaders) {
    return this.httpClient.put(`${this.baseUrl}/user/`, {}, { headers });
  }

  update(id: string, headers: HttpHeaders) {
    return this.httpClient.patch(`${this.baseUrl}/user/${id}`, {}, { headers });
  }

  delete(id: string, headers: HttpHeaders) {
    return this.httpClient.delete(`${this.baseUrl}/user/${id}`, { headers });
  }
}