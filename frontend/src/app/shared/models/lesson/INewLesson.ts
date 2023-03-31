import { INewQuestion } from './INewQuestion';
import { INewTag } from './INewTag';

export interface INewLesson {
    name: string,
    description: string,
    mediaPath: string,
    languageLevel: number,
    startAt: Date,
    limitOfUsers?: number,
    youtubeVideoId: string,
    zoomMeetingLink: string,
    questions: INewQuestion[],
    tags: INewTag[],
}
