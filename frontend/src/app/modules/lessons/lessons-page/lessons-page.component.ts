import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog'
import { YoutubePlayerComponent } from '@shared/components/youtube-player/youtube-player.component';

@Component({
  selector: 'app-lessons-page',
  templateUrl: './lessons-page.component.html',
  styleUrls: ['./lessons-page.component.sass']
})
export class LessonsPageComponent implements OnInit {

  constructor(private dialogRef: MatDialog) { }

  openDialog() {
    this.dialogRef.open(YoutubePlayerComponent, {
      maxWidth: '100vw',
      maxHeight: '100vh',
      height: '80%',
      width: '80%',
    });
  }

  ngOnInit(): void {
  }

}
