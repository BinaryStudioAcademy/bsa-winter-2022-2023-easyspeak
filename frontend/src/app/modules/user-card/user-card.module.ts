import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { UserCardComponent } from '@modules/user-card/user-card.component';
import { SharedModule } from '@shared/shared.module';

@NgModule({
    declarations: [UserCardComponent],
    imports: [CommonModule, SharedModule],
    exports: [
        UserCardComponent,
    ],
})
export class UserCardModule {}
