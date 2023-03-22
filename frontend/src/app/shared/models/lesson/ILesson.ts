import { IQuestion } from "./IQuestion";
import { ITag } from "./ITag";

export interface ILesson {
    description: string,
    id: number,
    languageLevel: number,
    mediaPath: string,
    name: string,
    questions: IQuestion[],
    startAt: string,
    subscribersCount: number,
    tags: ITag[],
    user: null
}
