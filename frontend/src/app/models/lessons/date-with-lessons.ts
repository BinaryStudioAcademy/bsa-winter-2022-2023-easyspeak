import { Lesson } from './lesson';

export interface DateWithLessons {
    lessonsDate: string;
    lessons: Lesson[];
    lessonsColumn1: Lesson[];
    lessonsColumn2: Lesson[];
}
