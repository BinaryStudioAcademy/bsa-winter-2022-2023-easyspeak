import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { UserCardModule } from '@modules/user-card/user-card.module';

import { FriendsPageComponent } from './friends-page/friends-page.component';
import { FriendsRoutingModule } from './friends-routing.module';

@NgModule({
    declarations: [
        FriendsPageComponent,
    ],
    imports: [
        CommonModule,
        FriendsRoutingModule,
        UserCardModule,
    ],
})
export class FriendsModule { }
