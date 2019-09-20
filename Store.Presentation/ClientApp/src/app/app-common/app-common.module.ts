import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppCommonRoutingModule } from './app-common-routing.module';
import { NotFoundComponent } from './not-found/not-found.component';


@NgModule({
  declarations: [NotFoundComponent],
  imports: [
    CommonModule,
    AppCommonRoutingModule
  ],
  providers: [],
  exports: [NotFoundComponent]
})
export class AppCommonModule { }
