import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { INewLesson } from '@shared/models/lesson/INewLesson';
import { NewQuestion } from '@shared/models/lesson/NewQuestion';
import { NewTag } from '@shared/models/lesson/NewTag';
import Utils from '@shared/utils/lesson.utils';

import { LessonsService } from 'src/app/services/lessons.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
    selector: 'app-lessons-create',
    templateUrl: './lessons-create.component.html',
    styleUrls: ['./lessons-create.component.sass'],
})
export class LessonsCreateComponent implements OnInit {
    tagsList: string[] = Utils.tagsList;

    myForm: FormGroup;

    constructor(
        private fb: FormBuilder,
        private lessonService: LessonsService,
        private dialogRef: MatDialogRef<LessonsCreateComponent>,
        private notificationService: NotificationService,
    ) {}

    ngOnInit(): void {
        this.myForm = Utils.group(this.fb);
    }

    get name() {
        return this.myForm.get('name');
    }

    get description() {
        return this.myForm.get('description');
    }

    get date() {
        return this.myForm.get('date');
    }

    get questions() {
        return this.myForm.get('questions');
    }

    get tags() {
        return this.myForm.get('tags');
    }

    createLesson() {
        const lessonQuestions: NewQuestion[] =
            this.questions?.value
                .split('\n')
                .filter((entry: string) => entry.trim() !== '')
                .map((element: string) => new NewQuestion(element, []));

        const lessonTags: NewTag[] = this.tags?.value.map((element: string) => new NewTag(element));

        const lessonToCreate: INewLesson = {
            name: this.name?.value,
            description: this.description?.value,
            mediaPath: '',
            startAt: new Date(this.date?.value),
            questions: lessonQuestions,
            tags: lessonTags,
            limitOfUsers: 1,
        };

        this.lessonService.createLesson(lessonToCreate).subscribe(_ =>{
            this.dialogRef.close();

            this.notificationService.showSuccess('Successfully created a lesson!', 'Success');
        });
    }
}
