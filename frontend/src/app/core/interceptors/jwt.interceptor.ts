import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { from, Observable } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService) {}

    public intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        const accessToken = localStorage.getItem('accessToken');

        let reqCloned = req;

        if (this.authService.isAuthenticated() && accessToken) {
            reqCloned = req.clone({ setHeaders: { Authorization: `Bearer ${accessToken}` } });

            return next.handle(reqCloned);
        }

        return from(this.authService.refreshToken()).pipe(
            mergeMap(() => {
                const newToken = localStorage.getItem('accessToken');

                if (newToken) {
                    reqCloned = req.clone({ setHeaders: { Authorization: `Bearer ${newToken}` } });
                }

                return next.handle(reqCloned);
            }),
        );
    }
}
