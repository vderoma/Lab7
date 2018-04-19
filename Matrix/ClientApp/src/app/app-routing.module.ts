import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './member/member/member-list/member-list.component';
import { MessagesComponent } from './messages/messages/messages/messages.component';
import { FriendslistComponent } from './friendslist/friendslist/friendslist.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'members', component: MemberListComponent },
  { path: 'friends', component: FriendslistComponent },
  { path: 'messages', component: MessagesComponent },];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
