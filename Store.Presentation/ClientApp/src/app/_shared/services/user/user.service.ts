import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserItem } from '../../models/user/UserItem';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll(): Observable<UserItem[]> {
    return this.httpClient.get<UserItem[]>(`${this.baseUrl}/user/`);
  }

  findById(id: string): Observable<UserItem> {
    return this.httpClient.get<UserItem>(`${this.baseUrl}/user/${id}`);
  }

  create() {
    return this.httpClient.put(`${this.baseUrl}/user/`, {});
  }

  update(id: string) {
    return this.httpClient.patch(`${this.baseUrl}/user/${id}`, {});
  }

  delete(id: string) {
    return this.httpClient.delete(`${this.baseUrl}/user/${id}`);
  }
}