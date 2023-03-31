import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ChangePasswordComponent } from './change-password/change-password.component';
import { CheckEmailComponent } from './check-email/check-email.component';
import { ForgotPasswordPageComponent } from './forgot-password-page/forgot-password-page.component';
import { WriteEmailComponent } from './write-email/write-email.component';

const routes: Routes = [
    {
        path: '',
        component: ForgotPasswordPageComponent,
        children: [
            {
                path: '',
                component: WriteEmailComponent,
            },
            {
                path: 'check-email',
                component: CheckEmailComponent,
            },
            {
                path: 'change-password',
                component: ChangePasswordComponent,
                pathMatch: 'prefix',
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ForgotPasswordRoutingModule {}
