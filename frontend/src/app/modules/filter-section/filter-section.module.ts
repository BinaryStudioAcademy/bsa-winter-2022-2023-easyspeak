import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { FilterSectionComponent } from '@modules/filter-section/filter-section/filter-section.component';
import { SharedModule } from '@shared/shared.module';

@NgModule({
    declarations: [FilterSectionComponent],
    imports: [
        CommonModule,
        MatIconModule,
        SharedModule,
    ],
})
export class FilterSectionRoutingModule { }
