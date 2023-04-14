import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MainModule } from '@modules/main/main.module';
import { UserCardModule } from '@modules/user-card/user-card.module';
import { SharedModule } from '@shared/shared.module';

import { FilterSectionComponent } from './filter-section/filter-section.component';
import { PaginationComponent } from './pagination/pagination.component';
import { SocialPageComponent } from './social-page/social-page.component';
import { SocialPageRoutingModule } from './social-page-routing.module';

@NgModule({
    declarations: [
        SocialPageComponent,
        FilterSectionComponent,
        PaginationComponent,
    ],
    imports: [
        CommonModule,
        SocialPageRoutingModule,
        MainModule,
        UserCardModule,
        SharedModule,
        MatIconModule,
    ],
})
export class SocialPageModule { }
