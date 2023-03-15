/* eslint-disable no-unused-vars */
/* eslint-disable @typescript-eslint/no-unused-vars */
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { SuitableLessonComponent } from './suitable-lesson/suitable-lesson.component';

@NgModule({
    declarations: [SuitableLessonComponent],
    imports: [
        BrowserModule,
        CommonModule,
        BrowserAnimationsModule,
        MatFormFieldModule,
        MatDatepickerModule,
        MatInputModule,
        MatNativeDateModule,
        FormsModule,
        MatMenuModule,
        MatIconModule,
    ],
    providers: [],
    bootstrap: [SuitableLessonComponent],
})
export class TimeTable1Module {}
