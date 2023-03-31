import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';

import { ChangePasswordComponent } from './change-password/change-password.component';
import { CheckEmailComponent } from './check-email/check-email.component';
import { ForgotPasswordPageComponent } from './forgot-password-page/forgot-password-page.component';
import { WriteEmailComponent } from './write-email/write-email.component';
import { ForgotPasswordRoutingModule } from './forgot-password-routing.module';

@NgModule({
    declarations: [ForgotPasswordPageComponent,
        CheckEmailComponent,
        ChangePasswordComponent,
        WriteEmailComponent],
    imports: [MatIconModule,
        ForgotPasswordRoutingModule,
        CommonModule,
        FormsModule],

})
export class ForgotPasswordModule {}
