import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { UserDto } from '../models/userdto';

@Injectable()
export class UserService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  updateUser(id, updatedUser) {
    return this.http.put(this.baseUrl + '/users/updateuser/' + id, updatedUser);
  }

  getUsers(id) {
    return this.http.get<Array<UserDto>>(this.baseUrl + '/users/users');
  }
}
