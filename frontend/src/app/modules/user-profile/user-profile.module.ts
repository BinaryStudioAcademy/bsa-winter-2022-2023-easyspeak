import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '@modules/time-table/material/material.module';
import { SharedModule } from '@shared/shared.module';

import { SelectTopicsPageComponent } from './select-topics-page/select-topics-page.component';
import { UserDetailsComponent } from './user-details/user-details/user-details.component';
import { UserPasswordChangeComponent } from './user-password-change/user-password-change.component';
import { UserProfilePageComponent } from './user-profile-page/user-profile-page.component';
import { UserSubscriptionComponent } from './user-subscription/user-subscription.component';
import { UserProfileRoutingModule } from './user-profile-routing.module';

@NgModule({
    declarations: [
        SelectTopicsPageComponent,
        UserProfilePageComponent,
        UserDetailsComponent,
        UserSubscriptionComponent,
        UserPasswordChangeComponent,
    ],
    imports: [
        SharedModule,
        UserProfileRoutingModule,
        FormsModule,
        MaterialModule,
    ],
    exports: [
        SelectTopicsPageComponent,
    ],
})
export class UserProfileModule {}
