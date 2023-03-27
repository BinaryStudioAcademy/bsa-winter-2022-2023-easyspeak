import { NgModule } from '@angular/core';
import { FilterSectionRoutingModule } from '@modules/filter-section/filter-section.module';
import { LessonsModule } from '@modules/lessons/lessons.module';
import { TimeTable1Module } from '@modules/time-table/time-table.module';
import { UserProfileModule } from '@modules/user-profile/user-profile.module';
import { HeaderComponent } from '@shared/components/header/header.component';
import { MaterialModule } from '@shared/material/material.module';
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
        MaterialModule,
        FilterSectionRoutingModule,
        LessonsModule,
        TimeTable1Module,
        UserProfileModule,
    ],
    exports: [
        TimetablePageComponent
    ]
})
export class MainModule {}
