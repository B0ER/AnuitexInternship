import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/_shared/_services/authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  signInForm: FormGroup;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthenticationService,
    private router: Router) { }

  ngOnInit() {
    this.signInForm = this.formBuilder.group({
      login: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      rememberMe: [false]
    });
  }

  onSubmit() {
    this.submitted = true;

    if (this.signInForm.invalid) {
      return;
    }

    let formData = this.signInForm.value;

    this.authService.login(formData.login, formData.password, formData.rememberMe)
      .subscribe((jwt) => {
        this.router.navigate(['/']);
      });
  }

  onReset() {
    this.submitted = false;
    this.signInForm.reset();
  }
}
