import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RouterModule } from '@angular/router';
import { YouTubePlayerModule } from '@angular/youtube-player';
import { NgSelectModule } from '@ng-select/ng-select';
import { HeaderComponent } from '@shared/components/header/header.component';
import { RoundProgressBarComponent } from '@shared/components/round-progress-bar/round-progress-bar.component';
import { MaterialModule } from '@shared/material/material.module';
import { ImageCropperModule } from 'ngx-image-cropper';

import { AcceptCallComponent } from './components/accept-call/accept-call.component';
import { AvatarComponent } from './components/avatar/avatar.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { ConfirmComponent } from './components/confirm/confirm.component';
import { DropdownComponent } from './components/dropdown/dropdown.component';
import { InterestsDropdownComponent } from './components/interests-dropdown/interests-dropdown.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { ModalComponent } from './components/modal/modal.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { UserNotificationComponent } from './components/user-notification/user-notification.component';
import { YoutubePlayerComponent } from './components/youtube-player/youtube-player.component';
import { ClickOutsideDirective } from './directives/click-outside.directive';
import { PasswordVisibilityDirective } from './directives/password-visibility.directive';
import { ScrollToBottomDirective } from './directives/scroll-to-bottom-directive';
import { TooltipWhenOverflowDirective } from './directives/tooltip-when-overflow.directive';

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
        ImageCropperModule,
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
        InterestsDropdownComponent,
        UserNotificationComponent,
        HeaderComponent,
        PasswordVisibilityDirective,
        ClickOutsideDirective,
        TooltipWhenOverflowDirective,
        AvatarComponent,
        ScrollToBottomDirective,
        AcceptCallComponent,
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
        CalendarComponent,
        InterestsDropdownComponent,
        UserNotificationComponent,
        HeaderComponent,
        PasswordVisibilityDirective,
        TooltipWhenOverflowDirective,
        AvatarComponent,
        ScrollToBottomDirective,
        ImageCropperModule,
    ],
})
export class SharedModule {}
