import { NgModule } from '@angular/core';
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { HeaderComponent } from '@shared/components/header/header.component';
import { SharedModule } from '@shared/shared.module';

import { MainComponent } from './main-page/main-page.component';
import { TimetablePageComponent } from './timetable-page/timetable-page.component';
import { MainRoutingModule } from './main-routing.module';

@NgModule({
    declarations: [
        MainComponent,
        HeaderComponent,
        TimetablePageComponent,
    ],
    imports: [
        SharedModule,
        MainRoutingModule,
        MatButtonModule,
        MatToolbarModule,
        MatMenuModule,
        MatBadgeModule,
    ],
})
export class MainModule {}
