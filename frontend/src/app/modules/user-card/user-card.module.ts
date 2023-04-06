import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { UserCardComponent } from '@modules/user-card/user-card.component';
import { SharedModule } from '@shared/shared.module';

@NgModule({
    declarations: [UserCardComponent],
    imports: [CommonModule, SharedModule],
    schemas: [NO_ERRORS_SCHEMA,
        CUSTOM_ELEMENTS_SCHEMA],
    exports: [
        UserCardComponent,
    ],
})
export class UserCardModule {}
