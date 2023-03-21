import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { UserCardComponent } from '@modules/user-card/user-card.component';

@NgModule({
    declarations: [UserCardComponent],
    imports: [CommonModule, MatProgressSpinnerModule],
    exports: [
        UserCardComponent,
    ],
})
export class UserCardModule {

}
