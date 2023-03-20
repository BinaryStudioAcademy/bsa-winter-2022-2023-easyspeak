import { NewTag } from "@shared/models/lesson/NewTag";
import { NewQuestion } from "./NewQuestion";

export interface INewLesson {
    name: string,
    description: string,
    mediaPath: string,
    startAt: Date,
    limitOfUsers?: number,
    questions: NewQuestion[],
    tags: NewTag[],
}
