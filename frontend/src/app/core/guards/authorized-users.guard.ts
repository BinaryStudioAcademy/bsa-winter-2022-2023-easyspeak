import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '@core/services/auth.service';

@Injectable()
export class AuthorizedUsersGuard implements CanActivate {
    constructor(public auth: AuthService, public router: Router) {}

    canActivate(): boolean {
        if (this.auth.isAuthenticated()) {
            this.router.navigate(['/main']);

            return false;
        }

        return true;
    }
}
