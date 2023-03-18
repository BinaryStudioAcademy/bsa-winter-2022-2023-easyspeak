import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { YouTubePlayerModule } from '@angular/youtube-player';

import { DropdownComponent } from './components/dropdown/dropdown.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { YoutubePlayerComponent } from './components/youtube-player/youtube-player.component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        MatDialogModule,
        MatIconModule,
        YouTubePlayerModule,
    ],
    declarations: [LoadingSpinnerComponent, NotFoundComponent, YoutubePlayerComponent, DropdownComponent],
    exports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        LoadingSpinnerComponent,
        NotFoundComponent,
        DropdownComponent,
    ],
})
export class SharedModule {}
