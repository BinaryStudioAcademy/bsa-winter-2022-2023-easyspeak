import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '@shared/shared.module';

import { CropImageDialogComponent } from './crop-image.dialog/crop-image.dialog.component';
import { UserDetailsComponent } from './user-details/user-details/user-details.component';
import { UserPasswordChangeComponent } from './user-password-change/user-password-change.component';
import { UserProfilePageComponent } from './user-profile-page/user-profile-page.component';
import { UserSubscriptionComponent } from './user-subscription/user-subscription.component';
import { UserProfileRoutingModule } from './user-profile-routing.module';

@NgModule({
    declarations: [
        UserProfilePageComponent,
        UserDetailsComponent,
        UserSubscriptionComponent,
        UserPasswordChangeComponent,
        CropImageDialogComponent,
    ],
    imports: [
        SharedModule,
        UserProfileRoutingModule,
        FormsModule,
    ],
})
export class UserProfileModule {}
