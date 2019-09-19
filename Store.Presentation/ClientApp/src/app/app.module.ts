import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AccountModule } from './account/account.module';
import { UserModule } from './user/user.module';
import { BookModule } from './book/book.module';
import { AppRoutingModule } from './app-routing.module';
import { AppCommonModule } from './app-common/app-common.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppCommonModule,
    AppRoutingModule,
    AccountModule,
    UserModule,
    BookModule,

    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
