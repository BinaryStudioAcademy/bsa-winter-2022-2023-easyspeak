import { Lesson } from './lesson';

export interface DateWithLessons {
    lessonsDate: string;
    lessons: Lesson[];
}
