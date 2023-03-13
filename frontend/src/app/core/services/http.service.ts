import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class HttpService {
    // eslint-disable-next-line no-empty-function
    constructor(private httpClient: HttpClient, private baseUrl: string) {
    }

    get<T>(url: string): Observable<T[]> {
        return this.httpClient.get<T[]>(this.buildUrl(url))
            .pipe(
                catchError(this.handleError),
            );
    }

    getById<T>(url: string, id: string | number): Observable<T> {
        return this.httpClient.get<T>(`${this.buildUrl(url)}/${id}`)
            .pipe(
                catchError(this.handleError),
            );
    }

    post<T>(url: string, resource: T): Observable<any> {
        return this.httpClient.post(this.buildUrl(url), resource)
            .pipe(
                catchError(this.handleError),
            );
    }

    delete(url: string, id: string | number): Observable<any> {
        return this.httpClient.delete(`${this.buildUrl(url)}/${id}`)
            .pipe(
                catchError(this.handleError),
            );
    }

    put<T>(url: string, resource: T): Observable<any> {
        return this.httpClient.put(this.buildUrl(url), resource)
            .pipe(
                catchError(this.handleError),
            );
    }

    private handleError(err: HttpErrorResponse): Observable<never> {
        console.log(err);

        return throwError(() => err);
    }

    public buildUrl(url: string): string {
        return this.baseUrl + url;
    }
}
