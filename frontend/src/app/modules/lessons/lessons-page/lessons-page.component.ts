import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { langLevelsSample } from '@modules/filter-section/filter-section/filter-section.util';
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';
import { ILesson } from '@shared/models/lesson/ILesson';
import { LanguageLevels } from '@shared/models/lesson/LanguageLevels';

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

    @Input() selectedLanguageFilters: Set<string>;

    @Input() selectedInterestsFilters: Set<string>;

    @Input() selectedDateFilter: Date;

    lessons: Lesson[];

    constructor(private dialogRef: MatDialog, private lessonService: LessonsService) { }

    ngOnInit(): void {
        this.selectedDateFilter = new Date();

        this.getLessons();

        const formatter = new Intl.DateTimeFormat('en-US', { day: 'numeric', month: 'long', year: 'numeric', weekday: 'long' });
        const parts = formatter.formatToParts(this.selectedDateFilter);
        const formattedDate = `${parts[4].value} ${parts[2].value} ${parts[6].value}, ${parts[0].value}`;

        this.todayDate = formattedDate;
    }

    ngOnChanges(): void {
        this.getLessons();

        const formatter = new Intl.DateTimeFormat('en-US', { day: 'numeric', month: 'long', year: 'numeric', weekday: 'long' });
        const parts = formatter.formatToParts(new Date(this.selectedDateFilter.toISOString().slice(0, 10)));
        const formattedDate = `${parts[4].value} ${parts[2].value} ${parts[6].value}, ${parts[0].value}`;

        this.todayDate = formattedDate;
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
        this.lessonService.getFilteredLessons({
            languageLevels: Array.from(this.selectedLanguageFilters).map((level: string) => Object.values(LanguageLevels).indexOf(level)),
            tags: Array.from(this.selectedInterestsFilters).map((topic) => ({ name: topic })),
            date: new Date(this.selectedDateFilter.toISOString().slice(0, 10)),
        }).subscribe((response: ILesson[]) => {
            this.lessons = [];

            //TODO: When everything regarding user in the database is finished, update the lesson retrieval code

            response.forEach(lesson => {
                this.lessons.push({
                    id: lesson.id,
                    imgPath: lesson.mediaPath,
                    videoId: 'xqAriI87lFU',
                    title: lesson.name,
                    time: lesson.startAt.split('T')[1].substring(0, 5).replace(':', '.'),
                    tutorAvatarPath: '../../../../assets/lesson-mocks/Photo )Patient).png',
                    tutorFlagPath: '../../../../assets/lesson-icons/canada-test-flag.svg',
                    tutorName: 'Roger Vaccaro',
                    topics: lesson.tags.map((tag) => tag.name),
                    viewersCount: lesson.subscribersCount,
                    level: langLevelsSample[lesson.languageLevel].title,
                    isDisabled: (new Date() > new Date(lesson.startAt)),
                });
            });
        });
    }

    getLessonsUnavailableMessage(): string {
        const noInterests = !this.selectedInterestsFilters.size;
        const noLanguages = !this.selectedLanguageFilters.size;

        if (noInterests && noLanguages) {
            return 'Oops, there are no lessons for this day. Please consider another date';
        } if (!noInterests && !noLanguages) {
            return 'Oops, there are no lessons with such filters for this day. Please consider another date';
        } if (!noInterests && noLanguages) {
            return 'Oops, there are no lessons with such interests for this day. Please consider another date';
        }

        return 'Oops, there are no lessons with such levels for this day. Please consider another date';
    }
}
