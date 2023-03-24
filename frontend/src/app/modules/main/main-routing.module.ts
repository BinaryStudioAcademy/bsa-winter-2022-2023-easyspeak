import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from '@shared/components/not-found/not-found.component';

import { MainComponent } from './main-page/main-page.component';
import { SocialPageComponent } from './social-page/social-page.component';
import { TimetablePageComponent } from './timetable-page/timetable-page.component';

const routes: Routes = [
    {
        path: '',
        component: MainComponent,
        children: [
            {
                path: 'social',
                component: SocialPageComponent,
                pathMatch: 'full',
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
export class MainRoutingModule {}
