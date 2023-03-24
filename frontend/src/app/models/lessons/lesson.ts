export interface Lesson {
    id: number;
    imgPath: string;
    videoId: string;
    title: string;
    time: string;
    tutorAvatarPath: string;
    tutorFlagPath: string;
    tutorName: string;
    topics: string[];
    viewersCount: number;
    level: string;
    isDisabled: boolean;
}
