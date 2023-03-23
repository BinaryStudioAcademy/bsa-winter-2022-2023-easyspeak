import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SessionCallComponent } from '@modules/session-call/session-call/session-call.component';

import { SessionCallRoutingModule } from './session-call-routing.module';

@NgModule({
    declarations: [SessionCallComponent],
    imports: [
        CommonModule,
        SessionCallRoutingModule,
    ],
})
export class SessionCallModule { }
