import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UserDetailsComponent } from './user-details/user-details/user-details.component';
import { UserPasswordChangeComponent } from './user-password-change/user-password-change.component';
import { UserProfilePageComponent } from './user-profile-page/user-profile-page.component';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'details',
        pathMatch: 'full',
    },
    {
        path: '',
        component: UserProfilePageComponent,
        children: [
            {
                path: 'details',
                component: UserDetailsComponent,
                pathMatch: 'full',
            },
            {
                path: 'change-pass',
                component: UserPasswordChangeComponent,
                pathMatch: 'full',
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UserProfileRoutingModule {}
