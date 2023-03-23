import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RouterModule } from '@angular/router';
import { YouTubePlayerModule } from '@angular/youtube-player';
import { NgSelectModule } from '@ng-select/ng-select';
import { RoundProgressBarComponent } from '@shared/components/round-progress-bar/round-progress-bar.component';
import { MaterialModule } from '@shared/material/material.module';

import { ConfirmComponent } from './components/confirm/confirm.component';
import { DropdownComponent } from './components/dropdown/dropdown.component';
import { InterestsDropdownComponent } from './components/interests-dropdown/interests-dropdown.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { ModalComponent } from './components/modal/modal.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { YoutubePlayerComponent } from './components/youtube-player/youtube-player.component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,
        YouTubePlayerModule,
        NgSelectModule,
        MatProgressSpinnerModule,
        MatSnackBarModule,
    ],
    declarations: [
        LoadingSpinnerComponent,
        NotFoundComponent,
        YoutubePlayerComponent,
        DropdownComponent,
        ModalComponent,
        ConfirmComponent,
        RoundProgressBarComponent,
        InterestsDropdownComponent,
    ],
    exports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        LoadingSpinnerComponent,
        NotFoundComponent,
        DropdownComponent,
        NgSelectModule,
        ModalComponent,
        MaterialModule,
        RoundProgressBarComponent,
        InterestsDropdownComponent,
    ],
})
export class SharedModule {}
