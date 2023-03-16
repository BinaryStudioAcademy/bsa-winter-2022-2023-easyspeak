import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { INewLesson } from '@shared/models/lesson/INewLesson';

import { LessonsService } from 'src/app/services/lessons.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
    selector: 'app-lessons-create',
    templateUrl: './lessons-create.component.html',
    styleUrls: ['./lessons-create.component.sass'],
})
export class LessonsCreateComponent {
    lessonToCreate: INewLesson = {
        name: '',
        description: '',
        mediaPath: '',
        startsAt: new Date(),
        questions: [],
        tags: [],
    };

    tagsControl = new FormControl();

    tagsList: string[] = [
        'Architecture',
        'Arts',
        'Cars',
        'Celebrities',
        'Cooking',
        'Dancing',
        'Ecology',
        'Design',
        'History',
        'Fashion',
        'Medicine',
        'Technologies',
        'Pets',
        'Philosophy',
        'Photography',
        'Politics',
    ];

    questions = '';

    tags: string[] = [];

    constructor(
        private dialogRef: MatDialogRef<LessonsCreateComponent>,
        private lessonService: LessonsService,
        private notificationService: NotificationService,
    ) { }

    createLesson() {
        this.lessonToCreate.questions =
            this.questions
                .split('\n')
                .filter((entry) => entry.trim() !== '');

        this.lessonToCreate.tags = this.tags;

        if (this.lessonToCreate.name !== '' && this.lessonToCreate.description !== '' &&
            this.lessonToCreate.questions.length > 0 && this.lessonToCreate.tags.length > 0) {
            this.lessonService.createLesson(this.lessonToCreate);
            this.notificationService.showSuccess('Lesson was successfully created!', 'Success!');
            this.dialogRef.close();
        } else {
            this.notificationService.showError('Something went wrong.', 'Error!');
        }
    }
}
