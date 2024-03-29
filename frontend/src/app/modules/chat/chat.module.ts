import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { SharedModule } from '@shared/shared.module';

import { ChatPageComponent } from './chat-page/chat-page.component';
import { MessageGroupComponent } from './message-group/message-group.component';
import { ChatRoutingModule } from './chat-routing.module';

@NgModule({
    declarations: [ChatPageComponent, MessageGroupComponent],
    imports: [CommonModule, ChatRoutingModule, ReactiveFormsModule, MatInputModule, SharedModule],
})
export class ChatModule {}
