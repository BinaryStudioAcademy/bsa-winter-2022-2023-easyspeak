import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class HttpService {
    private baseUrl: string = environment.coreUrl;

    constructor(private httpClient: HttpClient) {}

    get<T>(url: string): Observable<T[]> {
        return this.httpClient.get<T[]>(this.buildUrl(url)).pipe(catchError(this.handleError));
    }

    getById<T>(url: string, id: string | number) {
        return this.httpClient.get<T>(`${this.buildUrl(url)}/${id}`).pipe(catchError(this.handleError));
    }

    post<T>(url: string, resource: any) {
        return this.httpClient.post<T>(this.buildUrl(url), resource).pipe(catchError(this.handleError));
    }

    delete(url: string, id: string | number) {
        return this.httpClient.delete(`${this.buildUrl(url)}/${id}`).pipe(catchError(this.handleError));
    }

    put<T>(url: string, resource: T) {
        return this.httpClient.put<T>(this.buildUrl(url), resource).pipe(catchError(this.handleError));
    }

    private handleError(err: HttpErrorResponse) {
        return throwError(() => err);
    }

    public buildUrl(url: string): string {
        return this.baseUrl + url;
    }
}
