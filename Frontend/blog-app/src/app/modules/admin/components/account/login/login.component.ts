import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AccountService } from 'src/app/services/account/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private accountService: AccountService,
    private router: Router) { }

  ngOnInit() {
  }

  loginForm = new FormGroup({
    userName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });

  async onSubmit() {
    try {
      var token = await this.accountService.loginAsync(this.loginForm.value);
      localStorage.setItem('token', token.data);
      this.router.navigate(['/', 'blog']);
    }
    catch (e) {
      console.error(e);
    }
  }
}
