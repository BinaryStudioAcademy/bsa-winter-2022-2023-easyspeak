import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { SharedModule } from '@shared/shared.module';

import { ChatPageComponent } from './chat-page/chat-page.component';
import { ChatRoutingModule } from './chat-routing.module';

@NgModule({
    declarations: [ChatPageComponent],
    imports: [CommonModule, ChatRoutingModule, ReactiveFormsModule, MatInputModule, SharedModule],
})
export class ChatModule {}
