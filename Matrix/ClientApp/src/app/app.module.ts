import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';

import { FormsModule } from '@angular/forms';
import { AuthService } from './services/auth.service';

import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { AlertModule } from 'ngx-bootstrap/alert';
import { JwtModule } from '@auth0/angular-jwt';
import { UserService } from './services/user.service';
import { MemberListComponent } from './member/member/member-list/member-list.component';
import { MemberCardComponent } from './member/member/member-card/member-card.component';
import { MessagesComponent } from './messages/messages/messages/messages.component';
import { FriendslistComponent } from './friendslist/friendslist/friendslist.component';
import { MemberDetailsComponent } from './member/member/member-details/member-details.component';
import { TimeAgoPipe } from 'time-ago-pipe';
import { MemberEditComponent } from './member/member/member-edit/member-edit.component';
import { PhotoEditorComponent } from './photo-editor/photo-editor.component';


export function tokenGetter() {
  return localStorage.getItem('token');
}
@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    MemberListComponent,
    MemberCardComponent,
    MessagesComponent,
    FriendslistComponent,
    MemberDetailsComponent,
    TimeAgoPipe,
    MemberEditComponent,
    PhotoEditorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    CollapseModule.forRoot(),
    AlertModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:4200, localhost:49770']
      }
    })
  ],
  providers: [AuthService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }



