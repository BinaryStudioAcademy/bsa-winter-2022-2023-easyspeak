import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminGuard } from '@core/guards/admin.guard';
import { MaterialModule } from '@shared/material/material.module';
import { SharedModule } from '@shared/shared.module';
import { MarkdownModule } from 'ngx-markdown';

import { LessonComponent } from './lesson/lesson.component';
import { LessonsCreateComponent } from './lessons-create/lessons-create.component';
import { LessonsPageComponent } from './lessons-page/lessons-page.component';
import { LessonsRoutingModule } from './lessons-routing.module';

@NgModule({
    declarations: [LessonsPageComponent, LessonsCreateComponent, LessonComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MaterialModule,
        LessonsRoutingModule,
        SharedModule,
        MarkdownModule.forChild()],
    exports: [LessonsPageComponent, LessonComponent],
    providers: [AdminGuard],
})
export class LessonsModule {}
