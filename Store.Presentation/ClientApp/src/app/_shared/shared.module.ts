import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from './services/authentication/authentication.service';
import { BookService } from './services/book/book.service';
import { UserService } from './services/user/user.service';
import { NotFoundComponent } from './components/not-found/not-found.component';


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
