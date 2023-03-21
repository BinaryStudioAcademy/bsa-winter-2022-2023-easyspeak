import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { YouTubePlayerModule } from '@angular/youtube-player';

import { ConfirmComponent } from './components/confirm/confirm.component';
import { DropdownComponent } from './components/dropdown/dropdown.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { ModalComponent } from './components/modal/modal.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { YoutubePlayerComponent } from './components/youtube-player/youtube-player.component';
import { RoundProgressBarComponent } from './components/round-progress-bar/round-progress-bar.component';
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";

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
        MatButtonModule,
        MatProgressSpinnerModule,
    ],
    declarations: [LoadingSpinnerComponent, NotFoundComponent, YoutubePlayerComponent, DropdownComponent, ModalComponent, ConfirmComponent, RoundProgressBarComponent],
    exports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        LoadingSpinnerComponent,
        NotFoundComponent,
        DropdownComponent,
        ModalComponent,
        RoundProgressBarComponent
    ],
})
export class SharedModule {}
