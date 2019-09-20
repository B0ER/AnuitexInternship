import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PrintingEditionService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll() {
    return this.httpClient.get(`${this.baseUrl}api/book/`);
  }

  findById(id: string) {
    return this.httpClient.get(`${this.baseUrl}api/book/${id}`);
  }

  create() {
    return this.httpClient.put(`${this.baseUrl}api/book/`, {});
  }

  update(id: string) {
    return this.httpClient.patch(`${this.baseUrl}api/book/${id}`, {});
  }

  delete(id: string) {
    return this.httpClient.delete(`${this.baseUrl}api/book/${id}`);
  }
}
