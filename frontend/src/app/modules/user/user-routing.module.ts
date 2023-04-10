import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminGuard } from '@core/guards/admin.guard';

import { TeachersPageComponent } from './teachers-page/teachers-page.component';

const routes: Routes = [
    {
        path: 'lessons',
        component: TeachersPageComponent,
        pathMatch: 'full',
        canActivate: [AdminGuard],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UserRoutingModule {}
