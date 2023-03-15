import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
import { ILesson } from '@shared/models/ILesson';

@Injectable({
  providedIn: 'root'
})
export class LessonsService {
    public routePrefix = '/api/lessons';

    constructor(private http: HttpService) { }

    createLesson(lesson: ILesson) {
        this.http.post(this.routePrefix, lesson);
    }
}
