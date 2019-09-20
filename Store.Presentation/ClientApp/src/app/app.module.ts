import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AccountModule } from './account/account.module';
import { UserModule } from './user/user.module';
import { PrintingEditionModule } from './printing-edition/printing-edition.module';
import { AppRoutingModule } from './app-routing.module';
import { ApiInterceptor } from './_shared/interceptors/api-interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    AccountModule,
    UserModule,
    PrintingEditionModule,

    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: ApiInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
