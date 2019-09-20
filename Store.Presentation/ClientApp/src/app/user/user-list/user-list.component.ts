import { Component, OnInit } from '@angular/core';
import { UserItem } from 'src/app/_shared/models/user/UserItem';
import { UserService } from 'src/app/_shared/services/user/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  private users: UserItem[];

  constructor(private userService: UserService) { 
    this.userService.getAll().subscribe(usersData => this.users = usersData);
  }

  ngOnInit() {
  }

}
