import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { RouterModule } from '@angular/router';
import { YouTubePlayerModule } from '@angular/youtube-player';
import { RoundProgressBarComponent } from '@shared/components/round-progress-bar/round-progress-bar.component';
import { MaterialModule } from '@shared/material/material.module';

import { ConfirmComponent } from './components/confirm/confirm.component';
import { DropdownComponent } from './components/dropdown/dropdown.component';
import { InterestsDropdownComponentComponent } from './components/interests-dropdown-component/interests-dropdown-component.component';
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
        MatProgressSpinnerModule,
    ],
    declarations: [
        LoadingSpinnerComponent,
        NotFoundComponent,
        YoutubePlayerComponent,
        DropdownComponent,
        ModalComponent,
        ConfirmComponent,
        RoundProgressBarComponent,
        InterestsDropdownComponentComponent,
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
        ModalComponent,
        RoundProgressBarComponent,
        InterestsDropdownComponentComponent,
    ],
})
export class SharedModule {}
