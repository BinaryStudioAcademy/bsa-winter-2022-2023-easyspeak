export interface Lesson {
    id: number;
    imgPath: string;
    videoId: string;
    zoomLink: string;
    title: string;
    time: string;
    tutorAvatarPath: string;
    tutorFlagPath: string;
    tutorName: string;
    topics: string[];
    subscribersCount: number;
    level: string;
    isSubscribed: boolean;
    startAt: Date;
}
