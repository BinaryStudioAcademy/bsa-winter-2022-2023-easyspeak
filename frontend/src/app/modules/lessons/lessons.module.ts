import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker'

import { LessonsCreateComponent } from './lessons-create/lessons-create.component';
import { LessonsPageComponent } from './lessons-page/lessons-page.component';
import { LessonsRoutingModule } from './lessons-routing.module';

@NgModule({
    declarations: [
        LessonsPageComponent,
        LessonsCreateComponent,
    ],
    imports: [
        CommonModule,
        LessonsRoutingModule,
        MatFormFieldModule,
        FormsModule,
        MatInputModule,
        MatButtonModule,
        MatDatepickerModule
    ],
})
export class LessonsModule { }
