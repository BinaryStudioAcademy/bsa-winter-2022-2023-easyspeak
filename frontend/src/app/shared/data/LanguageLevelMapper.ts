import { LanguageLevel } from './languageLevel';

export function mapLanguageLevelToString(level: string): string {
    switch (level) {
        case 'B1':
            return 'B1 (Intermediate)';
        case 'B2':
            return 'B2 (Upper-Intermediate)';
        case 'C1':
            return 'C1 (Advanced)';
        case 'C2':
            return 'C2 (Proficient)';
        default:
            throw new Error(`Invalid language level: ${level}`);
    }
}

export function mapStringToLanguageLevel(str: string): LanguageLevel {
    switch (str) {
        case 'B1 (Intermediate)':
            return LanguageLevel.B1;
        case 'B2 (Upper-Intermediate)':
            return LanguageLevel.B2;
        case 'C1 (Advanced)':
            return LanguageLevel.C1;
        case 'C2 (Proficient)':
            return LanguageLevel.C2;
        default:
            throw new Error(`Invalid language level string: ${str}`);
    }
}
