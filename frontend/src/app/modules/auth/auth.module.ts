import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

import { SignUpComponent } from './sign-up/sign-up.component';
import { AuthRoutingModule } from './auth-routing.module';

@NgModule({
    declarations: [SignUpComponent],
    imports: [CommonModule, AuthRoutingModule, MatInputModule, MatFormFieldModule, MatSelectModule],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AuthModule {}
