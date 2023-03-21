import { NgModule } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

import { ForgotPasswordPageComponent } from './forgot-password-page/forgot-password-page.component';
import { ForgotPasswordRoutingModule } from './forgot-password-routing.module';
import { CheckEmailComponent } from './check-email/check-email.component';
import { ChagePasswordComponent } from './chage-password/chage-password.component';
import { WriteEmailComponent } from './write-email/write-email.component';

@NgModule({
    declarations: [ForgotPasswordPageComponent, CheckEmailComponent, ChagePasswordComponent, WriteEmailComponent],
    imports: [MatIconModule, ForgotPasswordRoutingModule],
})
export class ForgotPasswordModule {}
