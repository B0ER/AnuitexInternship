import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { AccountRoutingModule } from './account-routing.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AppCommonModule } from '../app-common/app-common.module';



@NgModule({
  declarations: [
    SignInComponent,
    SignUpComponent
  ],
  imports: [
    AppCommonModule,
    CommonModule,
    AccountRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class AccountModule { }
