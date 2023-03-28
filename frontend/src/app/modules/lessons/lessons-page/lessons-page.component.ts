import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { langLevelsSample } from '@modules/filter-section/filter-section/filter-section.util';
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';
import { ILesson } from '@shared/models/lesson/ILesson';
import { LanguageLevels } from '@shared/models/lesson/LanguageLevels';
import Utils from '@shared/utils/lesson.utils';
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

    @Input() selectedTopicsFilters: Set<string>;

    @Input() selectedLanguageFilters: Set<string>;

    @Input() selectedDateFilter: Date;

    lessons = Utils.lessons;

    readonly formatString = 'D MMMM YYYY, dddd';

    constructor(private dialogRef: MatDialog, private lessonService: LessonsService) {}

    ngOnInit(): void {
        this.todayDate = moment().format(this.formatString);
    }

    ngOnChanges(): void {
        this.getLessons();

        this.todayDate = moment(this.selectedDateFilter).format(this.formatString);
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
        this.dialogRef.open(LessonsCreateComponent, {
            maxWidth: '100vw',
            maxHeight: '100vh',
            height: '80%',
            width: '80%',
        });
    }

    getLessons() {
        this.lessonService
            .getFilteredLessons({
                languageLevels: Array.from(this.selectedLanguageFilters).map((level: string) =>
                    Object.values(LanguageLevels).indexOf(level)),
                tags: Array.from(this.selectedTopicsFilters).map((topic) => ({ name: topic })),
                date: new Date(this.selectedDateFilter?.toISOString().slice(0, 1)),
            })
            .subscribe((response: ILesson[]) => {
                this.lessons = [...this.mapLesson(response)];
            });
    }

    private mapLesson(response: ILesson[]): Lesson[] {
        return response.map(lesson => ({
            id: lesson.id,
            imgPath: lesson.mediaPath,
            videoId: 'xqAriI87lFU',
            title: lesson.name,
            time: moment(lesson.startAt).format(this.formatString),
            tutorAvatarPath: 'assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: 'assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: lesson.tags.map((tag) => tag.name),
            viewersCount: lesson.subscribersCount,
            level: langLevelsSample[lesson.languageLevel].title,
            isDisabled: new Date() > new Date(lesson.startAt),
        }));
    }
}
