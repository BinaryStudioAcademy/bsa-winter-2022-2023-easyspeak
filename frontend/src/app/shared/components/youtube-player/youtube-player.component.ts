import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-youtube-player',
  templateUrl: './youtube-player.component.html',
  styleUrls: ['./youtube-player.component.sass']
})
export class YoutubePlayerComponent implements OnInit {

    apiLoaded = false;

    videoId = 'xqAriI87lFU';
    videoWidth: number
    videoHeight: number

    ngOnInit() {
        this.videoWidth = window.innerWidth * 0.8;
        this.videoHeight = window.innerHeight * 0.8 - 4;

        if (!this.apiLoaded) {
        const tag = document.createElement('script');
        tag.src = 'https://www.youtube.com/iframe_api';
        document.body.appendChild(tag);
        this.apiLoaded = true;
        }
    }
}
