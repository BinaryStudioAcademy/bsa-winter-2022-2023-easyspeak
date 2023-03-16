import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { SelectTopicsPageComponent } from './select-topics-page/select-topics-page.component';
import { UserProfileRoutingModule } from './user-profile-routing.module';

@NgModule({
    declarations: [SelectTopicsPageComponent],
    imports: [SharedModule, UserProfileRoutingModule],
    exports: [
        SelectTopicsPageComponent,
    ],
})
export class UserProfileModule {}
