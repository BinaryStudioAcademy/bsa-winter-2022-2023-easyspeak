import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TeachersPageComponent } from './teachers-page/teachers-page.component';

const routes: Routes = [
    {
        path: 'lessons',
        component: TeachersPageComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UserRoutingModule {}
