import { ILessonUser } from './ILessonUser';
import { IQuestion } from './IQuestion';
import { ITag } from './ITag';

export interface ILesson {
    description: string;
    id: number;
    languageLevel: number;
    mediaPath: string;
    name: string;
    questions: IQuestion[];
    startAt: string;
    subscribersCount: number;
    youtubeVideoId: string;
    zoomMeetingLink: string;
    zoomMeetingLinkHost: string;
    tags: ITag[];
    user: ILessonUser;
    isSubscribed: boolean;
    isCanceled: boolean;
}
