import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComponentsRoutingModule } from './components-routing.module';
import { MatSelectModule } from '@angular/material/select'


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ComponentsRoutingModule,
    MatSelectModule
  ]
})
export class ComponentsModule { }
