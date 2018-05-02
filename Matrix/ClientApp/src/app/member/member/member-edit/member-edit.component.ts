import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {

  constructor(private userService: UserService, private auth: AuthService, private router: Router) { }

  update = {};
  id = JSON.parse(localStorage.getItem('user')).id;
  member: any = {};

  ngOnInit() {
  }
  
  updateUser() {
    this.update = { introduction: this.member.introduction, lookingFor: this.member.lookingFor, interests: this.member.interests, city: this.member.city };
    this.userService.updateUser(this.id, this.update).subscribe();
  }

}
