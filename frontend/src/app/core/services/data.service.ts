import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
import { Observable, of, tap } from 'rxjs';

enum LocalStorageEnumKeys {
    Tags = 'all_interests',
    Languages = 'all_languages',
    Timezones = 'all_timezones',
}

interface Tag {
    id: number,
    name: string;
    imageUrl: string;
}

@Injectable({
    providedIn: 'root',
})
export class DataService {
    public routePrefix = '/data';

    constructor(
        private httpService: HttpService,
    ) { }

    public getAllTags(): Observable<Tag[]> {
        return this.getConstant<Tag>(LocalStorageEnumKeys.Tags, 'tags');
    }

    public getAllLanguages(): Observable<string[]> {
        return this.getConstant<string>(LocalStorageEnumKeys.Languages, 'languages');
    }

    private getConstant<T>(localStorageKey: string, route: string) {
        const constants = localStorage.getItem(localStorageKey);

        if (constants) {
            return of(JSON.parse(constants));
        }

        return this.httpService.get<T[]>(`${this.routePrefix}/${route}`).pipe(
            tap((result) => {
                localStorage.setItem(localStorageKey, JSON.stringify(result));
            }),
        );
    }
}
