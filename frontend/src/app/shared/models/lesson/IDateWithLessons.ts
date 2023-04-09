import { ILesson } from './ILesson';

export interface IDateWithLessons {
    lessonsDate: string;
    lessons: ILesson[];
    lessonsColumn1: ILesson[];
    lessonsColumn2: ILesson[];
}
