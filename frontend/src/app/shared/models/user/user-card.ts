export interface UserCard {
    name: string,
    country: string,
    language?: string,
    imagePath: string,
    languageLevel: string
    status: number | null;
    tags: string[]
    flag: string;
}
