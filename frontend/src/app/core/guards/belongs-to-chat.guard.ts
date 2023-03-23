import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AuthService } from '@core/services/auth.service';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class BelongsToChatGuard implements CanActivate {
    constructor(private authService: AuthService) {
    }

    canActivate(
        // eslint-disable-next-line @typescript-eslint/no-unused-vars,no-unused-vars
        route: ActivatedRouteSnapshot,
        // eslint-disable-next-line @typescript-eslint/no-unused-vars,no-unused-vars
        state: RouterStateSnapshot,
    ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        // const currentUser = this.authService.getUserData();
        // const chatId = route.paramMap.get('room')
        // TODO After implement logic in ChatService for checking if user belongs to chat, add here this check
        return true;
    }
}
