import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BelongsToChatGuard } from '@core/guards/belongs-to-chat.guard';
import { SessionCallComponent } from '@modules/session-call/session-call/session-call.component';

const routes: Routes = [
    {
        path: ':room',
        component: SessionCallComponent,
        canActivate: [BelongsToChatGuard],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class SessionCallRoutingModule { }
