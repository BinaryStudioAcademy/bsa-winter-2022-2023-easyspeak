import { Injectable } from '@angular/core';
import { HttpService } from '@core/services/http.service';
import { IDateWithLessons } from '@shared/models/lesson/IDateWithLessons';
import { IIDayCard } from '@shared/models/lesson/IDayCard';
import { IFilter } from '@shared/models/lesson/IFilter';
import { ILesson } from '@shared/models/lesson/ILesson';
import { INewLesson } from '@shared/models/lesson/INewLesson';
import { Observable, Subject, tap } from 'rxjs';

import { Question } from 'src/app/models/lessons/question';

import { TeacherStatistics } from '../models/lessons/teacher-statistics';

@Injectable({
    providedIn: 'root',
})
export class LessonsService {
    public routePrefix = '/lessons';

    public lessonAdded$ = new Subject<void>();

    constructor(private http: HttpService) {}

    createLesson(lesson: INewLesson) {
        return this.http.post(this.routePrefix, lesson).pipe(
            tap(() => {
                this.lessonAdded$.next();
            }),
        );
    }

    getFilteredLessons(filter: IFilter) {
        return this.http.post<ILesson[]>(`${this.routePrefix}/filters`, filter);
    }

    getLessonsCount(date: string) {
        return this.http.get<IIDayCard[]>(`${this.routePrefix}/week/?Date=${date}`);
    }

    getQuestions(id: number): Observable<Question[]> {
        return this.http.get(`${this.routePrefix}/${id}/questions`);
    }

    getTeacherStatistics(): Observable<TeacherStatistics> {
        return this.http.get(`${this.routePrefix}/statistics`);
    }

    getTeacherLessonsAtPeriod(start: string, end: string): Observable<IDateWithLessons[]> {
        return this.http.get(`${this.routePrefix}/${start}/${end}`);
    }

    cancelLesson(id: number, lesson: ILesson) {
        return this.http.put(`${this.routePrefix}/cancel/${id}`, lesson);
    }
}
