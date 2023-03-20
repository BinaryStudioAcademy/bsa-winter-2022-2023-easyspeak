import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { LessonsPageComponent } from './lessons-page/lessons-page.component';
import { LessonsRoutingModule } from './lessons-routing.module';

@NgModule({
    declarations: [
        LessonsPageComponent,
    ],
    imports: [
        CommonModule,
        LessonsRoutingModule,
    ],
    exports: [LessonsPageComponent],
})
export class LessonsModule { }
