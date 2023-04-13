import { LanguageLevel } from './languageLevel';

export const mapLanguageLevelToString = (level: string) => {
    switch (level) {
        case LanguageLevel.B1:
            return 'B1 (Intermediate)';
        case LanguageLevel.B2:
            return 'B2 (Upper-Intermediate)';
        case LanguageLevel.C1:
            return 'C1 (Advanced)';
        case LanguageLevel.C2:
            return 'C2 (Proficient)';
        default:
            throw new Error(`Invalid language level: ${level}`);
    }
};
