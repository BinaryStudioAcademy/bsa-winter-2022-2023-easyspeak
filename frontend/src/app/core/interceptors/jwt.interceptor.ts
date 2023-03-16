import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    public intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        const accessToken = JSON.parse(localStorage.getItem('accessToken')!);
        if (accessToken) {
            req = req.clone({ setHeaders: { Authorization: `Bearer ${accessToken}` } });
        }
        return next.handle(req);
    }
}
