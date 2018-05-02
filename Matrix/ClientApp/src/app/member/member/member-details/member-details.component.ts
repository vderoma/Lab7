import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../../services/user.service';


@Component({
  selector: 'app-member-details',
  templateUrl: './member-details.component.html',
  styleUrls: ['./member-details.component.css']
})
export class MemberDetailsComponent implements OnInit {

  constructor(private userService: UserService, private activatedRoute: ActivatedRoute, private auth: AuthService, private router: Router) { }

  member = {};
  id = -1;
  ngOnInit() {
  }

  getUser(id) {
    this.userService.getUsers(id).subscribe(data => this.member = data);
  }

}
