export interface INewLesson {
    name: string,
    description: string,
    mediaPath: string,
    startsAt: Date,
    limitOfUsers?: number,
    questions: string[],
    tags: string[],
}
