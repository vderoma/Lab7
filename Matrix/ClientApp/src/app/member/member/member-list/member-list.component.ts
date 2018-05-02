import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  constructor(private userService: UserService) { }
  users = [];
  id: any = {};
  ngOnInit() {
    this.getUsers();
  }
  getUsers() {
    this.userService.getUsers(this.id).subscribe(p => this.users = p);
  }
}
