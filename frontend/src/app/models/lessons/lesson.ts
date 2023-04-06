export interface Lesson {
    id: number;
    imgPath: string;
    videoId: string;
    zoomLink: string;
    zoomLinkHost: string;
    title: string;
    time: Date;
    tutorAvatarPath: string;
    tutorFlagPath: string;
    tutorName: string;
    topics: string[];
    subscribersCount: number;
    level: string;
    isSubscribed: boolean;
    startAt: Date;
}
