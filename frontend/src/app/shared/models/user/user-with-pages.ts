import { UserCard } from 'src/app/shared/models/user/user-card';

export interface UserCardsWithPages {
    filteredCardsCount: number;
    userShortInfoDtos: UserCard[];
}
