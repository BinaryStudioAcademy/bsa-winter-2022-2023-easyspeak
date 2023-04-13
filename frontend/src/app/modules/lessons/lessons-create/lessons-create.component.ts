import { Component, forwardRef, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NG_VALUE_ACCESSOR } from '@angular/forms';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { mapStringToLanguageLevel } from '@shared/data/LanguageLevelMapper';
import { youtubeVideoLinkRegex } from '@shared/data/regex.util';
import { IIcon } from '@shared/models/IIcon';
import { INewLesson } from '@shared/models/lesson/INewLesson';
import { INewQuestion } from '@shared/models/lesson/INewQuestion';
import { LanguageLevels } from '@shared/models/lesson/LanguageLevels';
import Utils from '@shared/utils/lesson.utils';
import * as moment from 'moment';

import { LessonsService } from 'src/app/services/lessons.service';
import { NotificationService } from 'src/app/services/notification.service';

export const MY_FORMATS = {
    parse: {
        dateInput: 'LL',
    },
    display: {
        dateInput: 'D MMMM YYYY',
        monthYearLabel: 'MMM YYYY',
        dateA11yLabel: 'LL',
        monthYearA11yLabel: 'MMMM YYYY',
    },
};

@Component({
    selector: 'app-lessons-create',
    templateUrl: './lessons-create.component.html',
    styleUrls: ['./lessons-create.component.sass'],
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => this),
            multi: true,
        },
        {
            provide: DateAdapter,
            useClass: MomentDateAdapter,
            deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
        },
        {
            provide: MAT_DATE_FORMATS,
            useValue: MY_FORMATS,
        },
    ],
})
export class LessonsCreateComponent implements OnInit {
    tagsList: IIcon[] = [];

    timesList: string[] = Utils.timesList;

    levelsList: string[] = Utils.levelsList;

    time: string;

    level: string;

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
        this.myForm = Utils.group(this.fb);
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

        const lessonQuestions: INewQuestion[] = this.questions?.value
            .split('\n')
            .filter((entry: string) => entry.trim() !== '')
            .map((element: string) => ({ topic: element, subquestions: [] }));

        const lessonTags: IIcon[] = this.tagsList;

        const lessonToCreate: INewLesson = {
            name: this.name?.value,
            mediaPath: '',
            languageLevel: Object.values(LanguageLevels).indexOf(mapStringToLanguageLevel(this.level)),
            startAt,
            questions: lessonQuestions,
            tags: lessonTags.map(f => ({ id: f.id })),
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
