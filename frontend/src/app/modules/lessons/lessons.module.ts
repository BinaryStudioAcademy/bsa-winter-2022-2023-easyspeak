import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@modules/material/material.module';

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
        MaterialModule,
        LessonsRoutingModule,
    ],
    exports: [LessonsPageComponent],
})
export class LessonsModule { }
