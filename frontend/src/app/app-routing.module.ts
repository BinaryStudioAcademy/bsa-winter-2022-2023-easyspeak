import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@core/guards/auth.guard';
import { AuthorizedUsersGuard } from '@core/guards/authorized-users.guard';

const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./modules/landing/landing.module').then((m) => m.LandingModule),
    },
    {
        path: 'main',
        loadChildren: () => import('./modules/main/main.module').then((m) => m.MainModule),
        canActivate: [AuthGuard],
    },
    {
        path: 'auth',
        loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule),
        canActivate: [AuthorizedUsersGuard],
    },
    {
        path: 'profile',
        loadChildren: () => import('./modules/user-profile/user-profile.module').then((m) => m.UserProfileModule),
        canActivate: [AuthGuard],
    },
    {
        path: 'chat',
        loadChildren: () => import('./modules/chat/chat.module').then((m) => m.ChatModule),
        canActivate: [AuthGuard],
    },
    {
        path: 'session-call',
        loadChildren: () => import('./modules/session-call/session-call.module').then((m) => m.SessionCallModule),
        canActivate: [AuthGuard],
    },
    { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
