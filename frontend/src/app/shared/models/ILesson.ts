export interface ILesson {
    name: string,
    description: string,
    mediaPath: string,
    startsAt: Date,
    limitOfUsers?: number
}
