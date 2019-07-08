import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-follow-us',
  templateUrl: './follow-us.component.html',
  styleUrls: ['./follow-us.component.scss']
})
export class FollowUsComponent implements OnInit {

  constructor(private userService: UserService) { }

  userSocialLinks: UserSocialLinksViewModel;

  async ngOnInit() {
    const userName: string = "sandeshkarki"
    const userSocialLinksResponse = await this.userService.getUserSocialLinks(userName);
    this.userSocialLinks = userSocialLinksResponse.data.Data;
  }
}
