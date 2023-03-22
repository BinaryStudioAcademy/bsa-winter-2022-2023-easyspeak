import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@shared/material/material.module';

import { AuthPageComponent } from './auth-page/auth-page.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { AuthRoutingModule } from './auth-routing.module';

@NgModule({
    declarations: [SignUpComponent, SignInComponent, AuthPageComponent],
    imports: [CommonModule, AuthRoutingModule, MaterialModule, FormsModule, ReactiveFormsModule],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AuthModule {}
