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
import { UserNotificationComponent } from './components/user-notification/user-notification.component';
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
        MatButtonModule,
    ],
    declarations: [
        LoadingSpinnerComponent,
        NotFoundComponent,
        YoutubePlayerComponent,
        DropdownComponent,
        ModalComponent,
        ConfirmComponent,
        UserNotificationComponent,
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
        UserNotificationComponent,
    ],
})
export class SharedModule {}
