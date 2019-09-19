import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  signUpForm: FormGroup;
  submitted: boolean = false;
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.signUpForm = this.formBuilder.group({
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required, Validators.minLength(6)]],
      PasswordRepeat: ['', [Validators.required, Validators.minLength(6)]]
    },
      {
        validators: (formGroup: FormGroup) => {
          const control = formGroup.controls['Password'];
          const matchingControl = formGroup.controls['PasswordRepeat'];

          if (matchingControl.errors && !matchingControl.errors.mustMatch) {
            // return if another validator has already found an error on the matchingControl
            return;
          }

          // set error on matchingControl if validation fails
          if (control.value !== matchingControl.value) {
            matchingControl.setErrors({ mustMatch: true });
          } else {
            matchingControl.setErrors(null);
          }
        }
      });
  }

  onSubmit() {
    //debugger
    this.submitted = true;

    if (this.signUpForm.invalid) {
      return;
    }
    alert(JSON.stringify(this.signUpForm.value));
  }

  onReset() {
    this.submitted = false;
    this.signUpForm.reset();
  }

}
