import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '@shared/shared.module';

import { ChatPageComponent } from './chat-page/chat-page.component';

const routes: Routes = [
    {
        path: '',
        component: ChatPageComponent,
    },
    {
        path: ':id',
        component: ChatPageComponent,
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes), SharedModule],
    exports: [RouterModule, SharedModule],
})
export class ChatRoutingModule {}
