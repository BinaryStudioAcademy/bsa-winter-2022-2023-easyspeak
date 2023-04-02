import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { langLevelsSample } from '@modules/filter-section/filter-section/filter-section.util';
import { ModalComponent } from '@shared/components/modal/modal.component';
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';
import { IModal } from '@shared/models/IModal';
import { ILesson } from '@shared/models/lesson/ILesson';
import { LanguageLevels } from '@shared/models/lesson/LanguageLevels';
import * as moment from 'moment';

import { Lesson } from 'src/app/models/lessons/lesson';
import { LessonsService } from 'src/app/services/lessons.service';

import { LessonsCreateComponent } from '../lessons-create/lessons-create.component';

@Component({
    selector: 'app-lessons-page',
    templateUrl: './lessons-page.component.html',
    styleUrls: ['./lessons-page.component.sass'],
})
export class LessonsPageComponent implements OnInit, OnChanges {
    todayDate: string;

    @Input() selectedLanguageFilters: string[] = [];

    @Input() selectedInterestsFilters: string[] = [];

    @Input() selectedDateFilter: Date;

    lessons: Lesson[];

    lessonsColumn1: Lesson[];

    lessonsColumn2: Lesson[];

    constructor(private dialogRef: MatDialog, private lessonService: LessonsService) {}

    ngOnInit(): void {
        this.selectedDateFilter = new Date();

        this.getLessons();

        this.todayDate = moment().format('DD MMMM YYYY, dddd');
    }

    ngOnChanges(): void {
        this.getLessons();

        this.todayDate = moment(this.selectedDateFilter).format('DD MMMM YYYY, dddd');
    }

    openDialog(videoId: string) {
        this.dialogRef.open(YoutubePlayerComponent, {
            maxWidth: '100vw',
            maxHeight: '100vh',
            height: '80%',
            width: '80%',
            data: {
                videoId,
            },
        });
    }

    openCreate() {
        const config: MatDialogConfig<IModal> = {
            data: {
                header: 'Add Group Class',
                hasButtons: false,
                component: LessonsCreateComponent,
            },
        };

        this.dialogRef.open(ModalComponent, config);
    }

    getLessons() {
        this.lessonService
            .getFilteredLessons({
                languageLevels: this.selectedLanguageFilters.map((level: string) =>
                    Object.values(LanguageLevels).indexOf(level)),
                tags: this.selectedInterestsFilters.map((topic) => ({ name: topic })),
                date: new Date(this.selectedDateFilter?.toISOString().slice(0, 10)),
            })
            .subscribe((response) => {
                this.lessons = this.mapLessons(response);
                this.lessonsColumn1 = this.lessons.filter((el, index) => index % 2 === 0);
                this.lessonsColumn2 = this.lessons.filter((el, index) => index % 2 === 1);
            });
    }

    private mapLessons(response: ILesson[]): Lesson[] {
        return response.map((lesson) => ({
            id: lesson.id,
            imgPath: lesson.mediaPath,
            videoId: lesson.youtubeVideoId,
            zoomLink: lesson.zoomMeetingLink,
            title: lesson.name,
            time: moment(lesson.startAt).format('hh.mm'),
            // TODO: Change tutor details to real when they are avaliable
            tutorAvatarPath: 'https://www.christopherjungo.com/uploads/2/4/9/4/24948269/screen-shot-2018-02-10-at-00-09-32_orig.png',
            tutorFlagPath: 'assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: lesson.tags.map((tag) => tag.name),
            subscribersCount: lesson.subscribersCount,
            level: langLevelsSample[lesson.languageLevel].title,
            isDisabled: new Date() > new Date(lesson.startAt) || lesson.isSubscribed,
        }));
    }

    getLessonsUnavailableMessage(): string {
        const noInterests = !this.selectedInterestsFilters.length;
        const noLanguages = !this.selectedLanguageFilters.length;

        switch (true) {
            case noInterests && noLanguages:
                return 'Oops, there are no lessons for this day. Please consider another date';
            case !noInterests && !noLanguages:
                return 'Oops, there are no lessons with such filters for this day. Please consider another date';
            case !noInterests && noLanguages:
                return 'Oops, there are no lessons with such interests for this day. Please consider another date';
            default:
                return 'Oops, there are no lessons with such levels for this day. Please consider another date';
        }
    }
}
