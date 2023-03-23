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
                path: '',
                redirectTo: 'social',
                pathMatch: 'full',
            },
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
