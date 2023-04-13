import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { LanguageLevel } from '@shared/data/languageLevel';
import { youtubeVideoLinkRegex } from '@shared/data/regex.util';
import { IIcon } from '@shared/models/IIcon';
import { INewLesson } from '@shared/models/lesson/INewLesson';
import { group, timesList } from '@shared/utils/lesson.utils';
import * as moment from 'moment';

import { LessonsService } from 'src/app/services/lessons.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
    selector: 'app-lessons-create',
    templateUrl: './lessons-create.component.html',
    styleUrls: ['./lessons-create.component.sass'],
})
export class LessonsCreateComponent implements OnInit {
    tagsList: IIcon[] = [];

    timesList: string[] = timesList;

    levelsList: LanguageLevel[];

    level: LanguageLevel | string;

    time: string;

    timeDropdownVisible = false;

    levelDropdownVisible = false;

    submitted: boolean;

    isPast: boolean;

    myForm: FormGroup;

    constructor(
        private fb: FormBuilder,
        private lessonService: LessonsService,
        private dialogRef: MatDialogRef<LessonsCreateComponent>,
        private notificationService: NotificationService,
    ) {}

    ngOnInit(): void {
        this.myForm = group(this.fb);
        this.levelsList = Object.values(LanguageLevel);
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

    get videoLink() {
        return this.myForm.get('videoLink');
    }

    get studentsCount() {
        return this.myForm.get('studentsCount');
    }

    get meetLink() {
        return this.myForm.get('meetLink');
    }

    expandTimeDropdown() {
        this.timeDropdownVisible = !this.timeDropdownVisible;
    }

    expandLevelDropdown() {
        this.levelDropdownVisible = !this.levelDropdownVisible;
    }

    updateTags(evendData: IIcon[]) {
        this.tagsList = evendData;
    }

    getYoutubeVideoId(link: string): string {
        const videoId = link.match(youtubeVideoLinkRegex);

        return videoId ? videoId[1] : '';
    }

    createLesson() {
        this.submitted = true;

        if (this.myForm.invalid || !this.time || !this.level || !this.tagsList.length) {
            return;
        }

        const [hours, minutes] = this.time.split('.');
        const startAt = moment(this.date?.value, 'YYYY-MM-DD')
            .set({ hour: parseInt(hours, 10), minute: parseInt(minutes, 10) })
            .toDate();

        this.isPast = startAt < moment().toDate();
        if (this.isPast) {
            return;
        }

        const lessonQuestions: string = this.questions?.value;

        const lessonTags: IIcon[] = this.tagsList;

        const lessonToCreate: INewLesson = {
            name: this.name?.value,
            mediaPath: '',
            languageLevel: this.level as LanguageLevel,
            startAt,
            questions: lessonQuestions,
            tags: lessonTags.map((f) => ({ id: f.id })),
            limitOfUsers: parseInt(this.studentsCount?.value, 10),
            youtubeVideoId: this.getYoutubeVideoId(this.videoLink?.value),
        };

        this.lessonService.createLesson(lessonToCreate).subscribe(
            () => {
                this.dialogRef.close();

                this.notificationService.showSuccess('Successfully created a lesson!', 'Success');
            },
            (error) => {
                this.notificationService.showError(`Lesson creation failed. ${error.message}`, 'Error');
            },
        );
    }

    updateTime(evendData: MouseEvent) {
        const target = evendData.target as HTMLElement;

        this.time = target.textContent || 'Time';
    }

    updateLevel(evendData: MouseEvent) {
        const target = evendData.target as HTMLElement;

        this.level = target.textContent || 'Level';
    }
}
