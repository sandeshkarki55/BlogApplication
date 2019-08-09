import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AccountService } from 'src/app/services/account/account.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/authentication/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private accountService: AccountService,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
  }

  loginForm = new FormGroup({
    userName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });

  async onSubmit() {
    try {
      var tokenResponse = await this.accountService.loginAsync(this.loginForm.value);
      var authResponse = this.authService.registerToken(tokenResponse.data);
      if (authResponse)
        this.router.navigate(['/', 'blog']);
    }
    catch (e) {
      console.error(e);
    }
  }
}
