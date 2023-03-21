import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
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
        MatIconModule,
        MatOptionModule,
        MatFormFieldModule,
        MatInputModule,
        FormsModule,
        MatSelectModule,
    ],
    exports: [
        SelectTopicsPageComponent,
    ],
})
export class UserProfileModule {}
