import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
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

    getQuestions(id: number) {
        return this.http.get(`${this.routePrefix}/${id}/questions`);
    }

    enrollLesson(userId: number, lessonId: number) {
        return this.http.put(`${this.routePrefix}/${userId}:${lessonId}`, null);
    }
}
