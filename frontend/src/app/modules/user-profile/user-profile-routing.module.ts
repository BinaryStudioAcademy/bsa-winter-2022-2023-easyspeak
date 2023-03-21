import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from '@shared/components/not-found/not-found.component';

import { UserDetailsComponent } from './user-details/user-details/user-details.component';
import { UserPasswordChangeComponent } from './user-password-change/user-password-change.component';
import { UserProfilePageComponent } from './user-profile-page/user-profile-page.component';
import { UserSubscriptionComponent } from './user-subscription/user-subscription.component';

const routes: Routes = [
    {
        path: '',
        component: UserProfilePageComponent,
        children: [
            {
                path: 'details/:id',
                component: UserDetailsComponent,
                pathMatch: 'full',
            },
            {
                path: 'subscription',
                component: UserSubscriptionComponent,
                pathMatch: 'full',
            },
            {
                path: 'change-pass',
                component: UserPasswordChangeComponent,
                pathMatch: 'full',
            },
            {
                path: '**',
                component: NotFoundComponent,
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
