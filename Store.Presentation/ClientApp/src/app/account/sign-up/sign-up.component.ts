import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/_shared/_services/authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  signUpForm: FormGroup;
  submitted: boolean = false;
  constructor(private formBuilder: FormBuilder, private authService: AuthenticationService, private router: Router) { }

  ngOnInit() {
    this.signUpForm = this.formBuilder.group({
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required, Validators.minLength(6)]],
      PasswordRepeat: ['', [Validators.required, Validators.minLength(6)]]
    },
      {
        validators: this.validatePasswordControl
      });
  }

  onSubmit() {
    this.submitted = true;

    if (this.signUpForm.invalid) {
      return;
    }

    let formData = this.signUpForm.value;

    this.authService.login(formData.login, formData.password, formData.rememberMe)
      .subscribe((jwt) => {
        this.router.navigate(['/']);
      });
  }

  onReset() {
    this.submitted = false;
    this.signUpForm.reset();
  }

  private validatePasswordControl(formGroup: FormGroup) {
    const control = formGroup.controls['Password'];
    const matchingControl = formGroup.controls['PasswordRepeat'];

    if (matchingControl.errors && !matchingControl.errors.mustMatch) {
      // return if another validator has already found an error on the matchingControl
      return;
    }

    // set error on matchingControl if validation fails
    if (control.value !== matchingControl.value) {
      control.setErrors({ mustMatch: true });
      matchingControl.setErrors({ mustMatch: true });
    } else {
      control.setErrors(null);
      matchingControl.setErrors(null);
    }
  }
}
