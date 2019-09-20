import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from './_services/authentication/authentication.service';
import { BookService } from './_services/book/book.service';
import { UserService } from './_services/user/user.service';
import { NotFoundComponent } from './not-found/not-found.component';


@NgModule({
  declarations: [NotFoundComponent],
  providers: [
    AuthenticationService,
    BookService,
    UserService
  ],
  imports: [
    CommonModule
  ],
  exports: [
    NotFoundComponent
  ]
})
export class SharedModule { }
