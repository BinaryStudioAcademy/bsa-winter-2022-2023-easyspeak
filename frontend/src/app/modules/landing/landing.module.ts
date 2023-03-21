import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { LandingPageComponent } from './landing-page/landing-page.component';
import { LandingRoutingModule } from './landing-routing.module';
import {UserCardModule} from "@modules/user-card/user-card.module";

@NgModule({
    declarations: [LandingPageComponent],
    imports: [SharedModule, LandingRoutingModule, UserCardModule],
})
export class LandingModule {}
