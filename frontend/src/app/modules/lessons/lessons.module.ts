import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';

import { LessonsCreateComponent } from './lessons-create/lessons-create.component';
import { LessonsPageComponent } from './lessons-page/lessons-page.component';
import { LessonsRoutingModule } from './lessons-routing.module';

import { MatDialogModule } from '@angular/material/dialog';

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
        MatDatepickerModule,
        MatOptionModule,
        MatSelectModule,
        ReactiveFormsModule,
        MatDialogModule,
    ],
})
export class LessonsModule { }
