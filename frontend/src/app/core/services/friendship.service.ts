import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
import { FriendDto } from '@shared/models/friendship/FriendDto';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class FriendshipService {
    public routePrefix = '/friends';

    constructor(private httpService: HttpService) {}

    createFriendship(friendDto: FriendDto): Observable<FriendDto> {
        return this.httpService.post<FriendDto>(`${this.routePrefix}`, friendDto);
    }

    acceptFriendship(friendDto: FriendDto): Observable<FriendDto> {
        return this.httpService.put<FriendDto>(`${this.routePrefix}/accept`, friendDto);
    }

    rejectFriendship(friendDto: FriendDto): Observable<FriendDto> {
        return this.httpService.put<FriendDto>(`${this.routePrefix}/reject`, friendDto);
    }
}
