import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'app-youtube-player',
    templateUrl: './youtube-player.component.html',
    styleUrls: ['./youtube-player.component.sass'],
})
export class YoutubePlayerComponent implements OnInit {
    apiLoaded = false;

    @Input() videoId: string;

    videoWidth: number;

    videoHeight: number;

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {videoId: string},
    ) { }

    ngOnInit() {
        this.videoWidth = window.innerWidth * 0.8;
        this.videoHeight = window.innerHeight * 0.8 - 4;
        this.videoId = this.data.videoId;

        if (!this.apiLoaded) {
            const tag = document.createElement('script');

            tag.src = 'https://www.youtube.com/iframe_api';
            document.body.appendChild(tag);
            this.apiLoaded = true;
        }
    }
}
