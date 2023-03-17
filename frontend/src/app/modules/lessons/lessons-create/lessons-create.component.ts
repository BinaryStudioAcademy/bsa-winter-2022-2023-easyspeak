import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { INewLesson } from '@shared/models/lesson/INewLesson';

import { LessonsService } from 'src/app/services/lessons.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
    selector: 'app-lessons-create',
    templateUrl: './lessons-create.component.html',
    styleUrls: ['./lessons-create.component.sass'],
})
export class LessonsCreateComponent implements OnInit {
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

    myForm: FormGroup;

    constructor(
        private fb: FormBuilder,
        private lessonService: LessonsService,
        private dialogRef: MatDialogRef<LessonsCreateComponent>,
        private notificationService: NotificationService,
    ) {}

    ngOnInit(): void {
        this.myForm = this.fb.group({
            name: ['', [
                Validators.required,
            ]],
            date: ['', [
                Validators.required,
            ]],
            questions: ['', [
                Validators.required,
            ]],
            tags: ['', [
                Validators.required,
            ]],
        })
    }

    get name() {
        return this.myForm.get('name');
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
        const lessonToCreate: INewLesson = {
            name: this.name?.value,
            description: '',
            mediaPath: '',
            startsAt: this.date?.value,
            questions: this.questions?.value.split('\n').filter((entry: string) => entry.trim()),
            tags: this.tags?.value,
        }

        this.lessonService.createLesson(lessonToCreate);

        this.dialogRef.close();

        this.notificationService.showSuccess('Successfully created a lesson!', 'Success');
    }
}
