import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { StatsCardComponent } from './stats-card/stats-card.component';
import { TeachersPageComponent } from './teachers-page/teachers-page.component';
import { UserRoutingModule } from './user-routing.module';

@NgModule({
    declarations: [TeachersPageComponent, StatsCardComponent],
    imports: [CommonModule, UserRoutingModule, SharedModule],
})
export class UserModule {}
