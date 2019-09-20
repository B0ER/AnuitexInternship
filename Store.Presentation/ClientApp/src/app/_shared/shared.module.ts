import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from './services/authentication/authentication.service';
import { PrintingEditionService } from './services/printing-edition/printing-edition.service';
import { UserService } from './services/user/user.service';
import { NotFoundComponent } from './components/not-found/not-found.component';


@NgModule({
  declarations: [NotFoundComponent],
  providers: [
    AuthenticationService,
    PrintingEditionService,
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
