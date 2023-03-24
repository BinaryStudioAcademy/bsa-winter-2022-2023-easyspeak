import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';
import { YouTubePlayerModule } from '@angular/youtube-player';
import { RoundProgressBarComponent } from '@shared/components/round-progress-bar/round-progress-bar.component';
import { MaterialModule } from '@shared/material/material.module';

import { CalendarComponent } from './components/calendar/calendar.component';
import { ConfirmComponent } from './components/confirm/confirm.component';
import { DropdownComponent } from './components/dropdown/dropdown.component';
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
        MatToolbarModule,
        MatIconModule,
        MatSnackBarModule,
        MatButtonModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatInputModule,
    ],
    declarations: [
        LoadingSpinnerComponent,
        NotFoundComponent,
        YoutubePlayerComponent,
        DropdownComponent,
        ModalComponent,
        ConfirmComponent,
        RoundProgressBarComponent,
        CalendarComponent,
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
        CalendarComponent,
    ],
})
export class SharedModule {}
