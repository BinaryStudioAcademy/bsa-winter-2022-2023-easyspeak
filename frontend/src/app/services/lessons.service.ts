import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
import { IIDayCard } from '@shared/models/lesson/IDayCard';
import { IFilter } from '@shared/models/lesson/IFilter';
import { ILesson } from '@shared/models/lesson/ILesson';
import { INewLesson } from '@shared/models/lesson/INewLesson';

@Injectable({
    providedIn: 'root',
})
export class LessonsService {
    public routePrefix = '/lessons';

    constructor(private http: HttpService) { }

    createLesson(lesson: INewLesson) {
        return this.http.post(this.routePrefix, lesson);
    }

    getFilteredLessons(filter: IFilter) {
        return this.http.post<ILesson[]>(`${this.routePrefix}/filters`, filter);
    }

    getLessonsCount(date: string) {
        return this.http.get<IIDayCard[]>(`${this.routePrefix}/week/?Date=${date}`);
    }

    getQuestions(id: number) {
        return this.http.get(`${this.routePrefix}/${id}/questions`);
    }
}
