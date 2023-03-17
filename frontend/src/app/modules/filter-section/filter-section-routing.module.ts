import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilterSectionComponent } from '@modules/filter-section/filter-section/filter-section.component';

const routes: Routes = [
    {
        path: '',
        component: FilterSectionComponent,
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class FilterSectionRoute {}
