import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PrintingEditionService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll(headers: HttpHeaders) {
    return this.httpClient.get(`${this.baseUrl}api/book/`, { headers });
  }

  findById(id: string, headers: HttpHeaders) {
    return this.httpClient.get(`${this.baseUrl}api/book/${id}`, { headers });
  }

  create(headers: HttpHeaders) {
    return this.httpClient.put(`${this.baseUrl}api/book/`, {}, { headers });
  }

  update(id: string, headers: HttpHeaders) {
    return this.httpClient.patch(`${this.baseUrl}api/book/${id}`, {}, { headers });
  }

  delete(id: string, headers: HttpHeaders) {
    return this.httpClient.delete(`${this.baseUrl}api/book/${id}`, { headers });
  }
}
