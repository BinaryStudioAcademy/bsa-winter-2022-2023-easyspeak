import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FriendsRoutingModule } from './friends-routing.module';
import { FriendsPageComponent } from './friends-page/friends-page.component';
import {UserCardModule} from "@modules/user-card/user-card.module";


@NgModule({
  declarations: [
    FriendsPageComponent
  ],
    imports: [
        CommonModule,
        FriendsRoutingModule,
        UserCardModule
    ]
})
export class FriendsModule { }
