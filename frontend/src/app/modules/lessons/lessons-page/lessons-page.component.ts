import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { langLevelsSample } from '@modules/filter-section/filter-section/filter-section.util';
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';
import { ILesson } from '@shared/models/lesson/ILesson';
import { LessonsService } from 'src/app/services/lessons.service';

import { LessonsCreateComponent } from '../lessons-create/lessons-create.component';

@Component({
    selector: 'app-lessons-page',
    templateUrl: './lessons-page.component.html',
    styleUrls: ['./lessons-page.component.sass'],
})
export class LessonsPageComponent implements OnInit {
    todayDate: string;

    lessons = [
        {
            imgPath: '../../../../assets/lesson-mocks/Photo-4.png',
            videoId: 'xqAriI87lFU',
            title: 'The Real New Yorker’s Sandwich',
            time: '11.00',
            tutorAvatarPath: '../../../../assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: '../../../../assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet', 'biology'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: true,
        },
        {
            imgPath: '../../../../assets/lesson-mocks/Photo-5.png',
            videoId: 'xqAriI87lFU',
            title: 'The Diet That Helps Fight Climate Change. How to help?',
            time: '11.00',
            tutorAvatarPath: '../../../../assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: '../../../../assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: false,
        },
        {
            imgPath: '../../../../assets/lesson-mocks/Photo-2.png',
            videoId: 'xqAriI87lFU',
            title: 'How to measure extreme distances',
            time: '11.00',
            tutorAvatarPath: '../../../../assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: '../../../../assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet', 'biology'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: false,
        },
        {
            imgPath: '../../../../assets/lesson-mocks/Photo-3.png',
            videoId: 'xqAriI87lFU',
            title: 'What’s so great about the Great Lakes?',
            time: '11.00',
            tutorAvatarPath: '../../../../assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: '../../../../assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet', 'biology'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: false,
        },
        {
            imgPath: '../../../../assets/lesson-mocks/Photo.png',
            videoId: 'xqAriI87lFU',
            title: 'No That Easy',
            time: '11.00',
            tutorAvatarPath: '../../../../assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: '../../../../assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet', 'sport', 'biology'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: false,
        },
        {
            imgPath: '../../../../assets/lesson-mocks/Photo-1.png',
            videoId: 'xqAriI87lFU',
            title: 'Is It Better to Be Polite or Frank?',
            time: '11.00',
            tutorAvatarPath: '../../../../assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: '../../../../assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet', 'sport', 'biology'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: false,
        },
    ];

    constructor(private dialogRef: MatDialog, private lessonService: LessonsService) { }

    ngOnInit(): void {
        const formatter = new Intl.DateTimeFormat('en-US', { day: 'numeric', month: 'long', year: 'numeric', weekday: 'long' });
        const parts = formatter.formatToParts(new Date());
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
            languageLevels: [],
            tags: [],
            date: new Date('2023-04-03')
        }).subscribe((response: ILesson[]) => {
            response.forEach(lesson => {
                this.lessons.push({
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
}
