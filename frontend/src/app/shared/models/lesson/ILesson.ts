import { ILessonUser } from './ILessonUser';
import { IQuestion } from './IQuestion';
import { ITag } from './ITag';

export interface ILesson {
    id: number;
    languageLevel: number;
    mediaPath: string;
    name: string;
    questions: IQuestion[];
    startAt: string;
    limitOfUsers: number;
    subscribersCount: number;
    youtubeVideoId: string;
    zoomMeetingLink: string;
    zoomMeetingLinkHost: string;
    tags: ITag[];
    user: ILessonUser;
    isSubscribed: boolean;
    isCanceled: boolean;
}
