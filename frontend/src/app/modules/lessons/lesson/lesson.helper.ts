import { ILesson } from '@shared/models/lesson/ILesson';

export const addTimeOffset = (date: string): string => {
    const offset = new Date().getTimezoneOffset();
    const dateObject = new Date(date);

    dateObject.setMinutes(dateObject.getMinutes() - offset);

    return dateObject.toString();
};

export const applyTimeOffset = (lessons: ILesson[]): ILesson[] =>
    lessons.map((lesson) => ({
        ...lesson,
        startAt: addTimeOffset(lesson.startAt),
    }));

export const filterColumn = (lessons: ILesson[], column: number): ILesson[] =>
    lessons.filter((el, index) => index % 2 === column - 1);
