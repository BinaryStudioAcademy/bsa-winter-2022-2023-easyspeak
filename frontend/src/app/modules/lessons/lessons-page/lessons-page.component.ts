import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';

@Component({
    selector: 'app-lessons-page',
    templateUrl: './lessons-page.component.html',
    styleUrls: ['./lessons-page.component.sass'],
})
export class LessonsPageComponent implements OnInit {
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

    constructor(private dialogRef: MatDialog) { }

    openDialog(videoId: string) {
        this.dialogRef.open(YoutubePlayerComponent, {
            maxWidth: '100vw',
            maxHeight: '100vh',
            height: '80%',
            width: '80%',
            data: {
                videoId: videoId
            }
        });
    }

    ngOnInit(): void {
    }
}
