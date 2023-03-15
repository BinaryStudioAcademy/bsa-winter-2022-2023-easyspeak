import { CommonModule } from '@angular/common';
import { LessonsPageComponent } from './lessons-page/lessons-page.component';
import { LessonsRoutingModule } from './lessons-routing.module';
import { NgModule } from '@angular/core';

@NgModule({
    declarations: [
        LessonsPageComponent,
    ],
    imports: [
        CommonModule,
        LessonsRoutingModule,
    ],
})
export class LessonsModule { }
