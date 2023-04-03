export interface Lesson {
    id: number;
    imgPath: string;
    videoId: string;
    zoomLink: string;
    title: string;
    time: Date;
    tutorAvatarPath: string;
    tutorFlagPath: string;
    tutorName: string;
    topics: string[];
    subscribersCount: number;
    level: string;
    isDisabled: boolean;
}
