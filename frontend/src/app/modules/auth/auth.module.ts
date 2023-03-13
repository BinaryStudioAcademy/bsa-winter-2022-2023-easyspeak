import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

// import { MatFormFieldModule } from '@angular/material/form-field';
import { SignUpComponent } from './sign-up/sign-up.component';
import { AuthRoutingModule } from './auth-routing.module';

@NgModule({
    declarations: [SignUpComponent],
    imports: [CommonModule, AuthRoutingModule],
})
export class AuthModule {}
