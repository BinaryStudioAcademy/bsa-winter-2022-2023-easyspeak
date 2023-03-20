import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { MaterialModule } from './material/material.module';
import { SuitableLessonComponent } from './suitable-lesson/suitable-lesson.component';
import { SuitableLessonDayComponent } from './suitable-lesson-day/suitable-lesson-day.component';

@NgModule({
    declarations: [SuitableLessonComponent, SuitableLessonDayComponent],
    imports: [CommonModule, MaterialModule],
    providers: [],
    exports: [SuitableLessonComponent, SuitableLessonDayComponent],
    bootstrap: [SuitableLessonComponent],
})
export class TimeTable1Module {}
