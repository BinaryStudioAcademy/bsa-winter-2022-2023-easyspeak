import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
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

    getQuestions(id: number) {
        return this.http.get(`${this.routePrefix}/${id}/questions`);
    }
}
