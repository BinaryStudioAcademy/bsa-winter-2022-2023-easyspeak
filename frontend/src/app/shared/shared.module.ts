import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { MaterialTestComponent } from './components/material-test/material-test.component';

import { MatButtonModule, MatIconModule, MatDividerModule } from '@angular/material';
@NgModule({
    imports: [CommonModule, RouterModule, FormsModule, ReactiveFormsModule, RouterModule, MatButtonModule, MatIconModule, MatDividerModule],
    declarations: [LoadingSpinnerComponent, NotFoundComponent, MaterialTestComponent],
    exports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        LoadingSpinnerComponent,
        NotFoundComponent,
        MaterialTestComponent
    ],
})
export class SharedModule {}
