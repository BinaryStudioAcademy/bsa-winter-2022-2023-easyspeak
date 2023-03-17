import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialModule } from './material/material.module';
import { SuitableLessonComponent } from './suitable-lesson/suitable-lesson.component';
import { SuitableLessonDayComponent } from './suitable-lesson-day/suitable-lesson-day.component';

@NgModule({
    declarations: [SuitableLessonComponent, SuitableLessonDayComponent],
    imports: [BrowserModule, CommonModule, BrowserAnimationsModule, FormsModule, MaterialModule],
    providers: [],
    bootstrap: [SuitableLessonComponent],
})
export class TimeTable1Module {}
