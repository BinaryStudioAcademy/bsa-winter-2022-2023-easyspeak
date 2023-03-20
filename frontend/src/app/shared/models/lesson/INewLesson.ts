import { INewTag } from './INewTag';

import { INewQuestion } from './INewQuestion';

export interface INewLesson {
    name: string,
    description: string,
    mediaPath: string,
    startAt: Date,
    limitOfUsers?: number,
    questions: INewQuestion[],
    tags: INewTag[],
}
