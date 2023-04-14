import { LanguageLevel } from './languageLevel';

export const fromStringToLanguageLevel = (level: string) => {
    switch (level) {
        case 'B1 (Intermediate)':
            return LanguageLevel.B1;
        case 'B2 (Upper-Intermediate)':
            return LanguageLevel.B2;
        case 'C1 (Advanced)':
            return LanguageLevel.C1;
        case 'C2 (Proficient)':
            return LanguageLevel.C2;
        default:
            throw new Error(`Invalid language level: ${level}`);
    }
};
