import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

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
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatOptionModule,
        MatDatepickerModule,
        MatDialogModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        LessonsRoutingModule,
    ],
    exports: [LessonsPageComponent],
})
export class LessonsModule { }
