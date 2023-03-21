import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
//import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { UserCardComponent } from '@modules/user-card/user-card.component';
import { RoundProgressBarComponent } from '@shared/components/round-progress-bar/round-progress-bar.component';

@NgModule({
    declarations: [UserCardComponent],
    imports: [CommonModule, RoundProgressBarComponent],
    exports: [
        UserCardComponent,
    ],
})
export class UserCardModule {

}
