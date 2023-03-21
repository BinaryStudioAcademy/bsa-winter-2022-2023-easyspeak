import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./modules/landing/landing.module').then((m) => m.LandingModule),
    },
    {
        path: 'main',
        loadChildren: () => import('./modules/main/main.module').then((m) => m.MainModule),
    },
    {
        path: 'auth',
        loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule),
    },
    {
        path: 'chat',
        loadChildren: () => import('./modules/chat/chat.module').then((m) => m.ChatModule),
    },
    {
        path: 'session-call',
        loadChildren: () => import('./modules/session-call/session-call.module').then((m) => m.SessionCallModule),
    },
    { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
