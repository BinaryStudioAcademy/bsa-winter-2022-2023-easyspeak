import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { INewLesson } from '@shared/models/lesson/INewLesson';
import { INewQuestion } from '@shared/models/lesson/INewQuestion';
import { INewTag } from '@shared/models/lesson/INewTag';
import { LanguageLevels } from '@shared/models/lesson/LanguageLevels';
import Utils from '@shared/utils/lesson.utils';

import { LessonsService } from 'src/app/services/lessons.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
    selector: 'app-lessons-create',
    templateUrl: './lessons-create.component.html',
    styleUrls: ['./lessons-create.component.sass'],
})
export class LessonsCreateComponent implements OnInit {
    tagsList: string[] = [];

    timesList: string[] = Utils.timesList;

    levelsList: string[] = Utils.levelsList;

    time: string;

    level: string;

    timeDropdownVisible = false;

    levelDropdownVisible = false;

    submitted: boolean;

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

    updateTags(evendData: string[]) {
        this.tagsList = evendData;
    }

    getYoutubeVideoId(link: string): string {
        const regex = /(?:youtube(?:-nocookie)?\.com\/(?:[^\/\n\s]+\/\S+\/|(?:v|vi|user)\/|\S*?[?&]v=)|youtu\.be\/)([a-zA-Z0-9_-]{11})/;
        const videoId = link.match(regex);

        return videoId ? videoId[1] : '';
    }

    createLesson() {
        this.submitted = true;

        if (this.myForm.invalid || !this.time || !this.level || !this.tagsList.length) {
            return;
        }

        const timeHours = parseInt(this.time.split('.')[0]);
        const timeMinutes = parseInt(this.time.split('.')[1]);
        const startAt = new Date(new Date(this.date?.value).setHours(timeHours, timeMinutes));

        const lessonQuestions: INewQuestion[] =
            this.questions?.value
                .split('\n')
                .filter((entry: string) => entry.trim() !== '')
                .map((element: string) => ({ topic: element, subquestions: [] }));

        const lessonTags: INewTag[] = this.tagsList.map((element: string) => ({ name: element }));

        const lessonToCreate: INewLesson = {
            name: this.name?.value,
            description: 'Description',
            mediaPath: '',
            languageLevel: Object.values(LanguageLevels).indexOf(this.level),
            startAt: startAt,
            questions: lessonQuestions,
            tags: lessonTags,
            limitOfUsers: parseInt(this.studentsCount?.value),
            youtubeVideoId: this.getYoutubeVideoId(this.videoLink?.value),
            zoomMeetingLink: this.meetLink?.value,
        };

        this.lessonService.createLesson(lessonToCreate).subscribe(() => {
            this.dialogRef.close();

            this.notificationService.showSuccess('Successfully created a lesson!', 'Success');
        });
    }

    updateTime(evendData: MouseEvent) {
        const target = evendData.target as HTMLElement;
        this.time = target.textContent || "Time";
    }

    updateLevel(evendData: MouseEvent) {
        const target = evendData.target as HTMLElement;
        this.level = target.textContent || "Level";
    }
}
