import { Component } from '@angular/core';
import { ILesson } from '@shared/models/ILesson';

import { LessonsService } from 'src/app/services/lessons.service';

@Component({
    selector: 'app-lessons-create',
    templateUrl: './lessons-create.component.html',
    styleUrls: ['./lessons-create.component.sass'],
})
export class LessonsCreateComponent {
    lessonToCreate: ILesson = {
        name: '',
        description: '',
        mediaPath: '',
        startsAt: new Date(),
    };

    constructor(private lessonService: LessonsService) {}

    createLesson() {
        console.log(this.lessonToCreate);
        this.lessonService.createLesson(this.lessonToCreate);
    }
}
