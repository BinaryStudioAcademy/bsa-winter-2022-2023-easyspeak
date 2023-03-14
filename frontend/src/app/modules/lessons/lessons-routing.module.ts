import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LessonsPageComponent } from './lessons-page/lessons-page.component';

const routes: Routes = [
    {
        path: '',
        component: LessonsPageComponent,
    },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LessonsRoutingModule { }
