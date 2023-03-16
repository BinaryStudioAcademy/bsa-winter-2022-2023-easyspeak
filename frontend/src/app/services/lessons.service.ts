import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
import { INewLesson } from '@shared/models/lesson/INewLesson';

@Injectable({
  providedIn: 'root'
})
export class LessonsService {
    public routePrefix = '/api/lessons';

    constructor(private http: HttpService) { }

    createLesson(lesson: INewLesson) {
        this.http.post(this.routePrefix, lesson);
    }
}
