import { UserFilter } from 'src/app/models/filters/userFilter';

export interface UserFilterPagination {
    filter: UserFilter | null,
    pageNumber: number | null,
}
