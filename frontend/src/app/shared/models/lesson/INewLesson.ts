import { LanguageLevel } from '@shared/data/languageLevel';

import { INewTag } from './INewTag';

export interface INewLesson {
    name: string;
    mediaPath: string;
    languageLevel: LanguageLevel;
    startAt: Date;
    limitOfUsers?: number;
    youtubeVideoId: string;
    questions: string;
    tags: INewTag[];
}
