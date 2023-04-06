import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from '@shared/components/not-found/not-found.component';

import { MainComponent } from './main-page/main-page.component';
import { TimetablePageComponent } from './timetable-page/timetable-page.component';

const routes: Routes = [
    {
        path: '',
        component: MainComponent,
        children: [
            {
                path: 'social',
                loadChildren: () => import('../social-page/social-page.module')
                    .then((m) => m.SocialPageModule),
            },
            {
                path: 'timetable',
                component: TimetablePageComponent,
                pathMatch: 'full',
            },
            {
                path: 'profile',
                loadChildren: () => import('../user-profile/user-profile.module').then((m) => m.UserProfileModule),
            },
            {
                path: 'user',
                loadChildren: () => import('../user/user.module').then((m) => m.UserModule),
            },
            {
                path: '**',
                component: NotFoundComponent,
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class MainRoutingModule {}
