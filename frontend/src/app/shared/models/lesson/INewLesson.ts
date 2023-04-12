import { INewQuestion } from './INewQuestion';
import { INewTag } from './INewTag';

export interface INewLesson {
    name: string,
    mediaPath: string,
    languageLevel: number,
    startAt: Date,
    limitOfUsers?: number,
    youtubeVideoId: string,
    questions: string,
    tags: INewTag[],
}
