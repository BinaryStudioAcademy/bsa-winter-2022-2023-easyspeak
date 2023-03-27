import { NgModule } from '@angular/core';
import { LessonsModule } from '@modules/lessons/lessons.module';
import { SharedModule } from '@shared/shared.module';

import { LandingPageComponent } from './landing-page/landing-page.component';
import { LandingRoutingModule } from './landing-routing.module';
import {MainModule} from "@modules/main/main.module";

@NgModule({
    declarations: [LandingPageComponent],
    imports: [SharedModule, LandingRoutingModule, LessonsModule, MainModule],
})
export class LandingModule {}
