import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserListComponent } from './user-list/user-list.component';
import { UserItemComponent } from './user-item/user-item.component';
import { AuthGuardService } from '../_shared/services/auth-guard.service';


const routes: Routes = [
  { path: '', component: UserListComponent, canActivate: [AuthGuardService], data: { allowRoles: ['Admin'] } },
  { path: ':id', component: UserItemComponent, canActivate: [AuthGuardService], data: { allowRoles: ['Admin'] } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
