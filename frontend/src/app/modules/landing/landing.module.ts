import { NgModule } from '@angular/core';
import { UserProfileModule } from '@modules/user-profile/user-profile.module';
import { SharedModule } from '@shared/shared.module';

import { LandingPageComponent } from './landing-page/landing-page.component';
import { LandingRoutingModule } from './landing-routing.module';
import {AuthModule} from "@modules/auth/auth.module";

@NgModule({
    declarations: [LandingPageComponent],
    imports: [SharedModule, LandingRoutingModule, UserProfileModule, AuthModule],
})
export class LandingModule {}
