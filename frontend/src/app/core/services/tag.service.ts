import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';

@Injectable({
    providedIn: 'root',
})

export class TagService {
    public routePrefix = '/tags';

    constructor(private httpService: HttpService) {}

    public getAllTags() {
        return this.httpService.get<string[]>(`${this.routePrefix}`);
    }
}
