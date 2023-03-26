import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

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
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class MainRoutingModule {}
