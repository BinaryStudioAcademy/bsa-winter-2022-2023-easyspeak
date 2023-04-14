import { UserCard } from 'src/app/shared/models/user/user-card';

export interface UserCardsWithPages {
    pagesCount: number;
    userShortInfoDtos: UserCard[];
}
