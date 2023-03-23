import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FilterSectionComponent } from '@modules/filter-section/filter-section/filter-section.component';
import { MaterialModule } from '@shared/material/material.module';
import { SharedModule } from '@shared/shared.module';

@NgModule({
    declarations: [FilterSectionComponent],
    imports: [CommonModule, MaterialModule, SharedModule],
    exports: [FilterSectionComponent],
})
export class FilterSectionRoutingModule {}
