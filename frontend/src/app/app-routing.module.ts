import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@core/guards/auth.guard';
import { AuthorizedUsersGuard } from '@core/guards/authorized-users.guard';
import { SelectTopicsPageComponent } from '@modules/user-profile/select-topics-page/select-topics-page.component';

const routes: Routes = [
    {
        path: 'auth',
        loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule),
        canActivate: [AuthorizedUsersGuard],
    },
    {
        path: 'topics',
        component: SelectTopicsPageComponent,
    },
    {
        path: 'session-call',
        loadChildren: () => import('./modules/session-call/session-call.module').then((m) => m.SessionCallModule),
        canActivate: [AuthGuard],
    },
    {
        path: '',
        pathMatch: 'full',
        loadChildren: () => import('./modules/landing/landing.module').then((m) => m.LandingModule),
    },
    {
        path: '',
        pathMatch: 'prefix',
        loadChildren: () => import('./modules/main/main.module').then((m) => m.MainModule),
        canActivate: [AuthGuard],
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
