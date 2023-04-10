import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { UserService } from '@core/services/user.service';

@Injectable()
export class AdminGuard implements CanActivate {
    constructor(public userService: UserService, public router: Router) {}

    canActivate(): boolean {
        return this.userService.isAdmin();
    }
}
