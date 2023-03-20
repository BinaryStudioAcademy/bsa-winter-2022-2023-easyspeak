import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { UserCardComponent } from '@modules/user-card/user-card.component';
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";

@NgModule({
    declarations: [UserCardComponent],
    imports: [CommonModule, MatProgressSpinnerModule],
    exports: [
        UserCardComponent,
    ],
})
export class UserCardModule {

}
