import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
import { ITag } from '@shared/models/user/ITag';

@Injectable({
    providedIn: 'root',
})

export class TagService {
    public routePrefix = '/tags';

    constructor(private httpService: HttpService) {}

    public getAllTags() {
        return this.httpService.get<ITag[]>(`${this.routePrefix}`);
    }
}
