import { INewQuestion } from './INewQuestion';
import { INewTag } from './INewTag';

export interface INewLesson {
    name: string,
    description: string,
    mediaPath: string,
    startAt: Date,
    limitOfUsers?: number,
    questions: INewQuestion[],
    tags: INewTag[],
}
