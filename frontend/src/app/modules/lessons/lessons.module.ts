import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { LessonsPageComponent } from './lessons-page/lessons-page.component';
import { LessonsRoutingModule } from './lessons-routing.module';
import { LessonsCreateComponent } from './lessons-create/lessons-create.component';

@NgModule({
    declarations: [
        LessonsPageComponent,
        LessonsCreateComponent,
    ],
    imports: [
        CommonModule,
        LessonsRoutingModule,
    ],
})
export class LessonsModule { }
