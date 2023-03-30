export class ColorGenerationUtils {
    static getHashOfString(fullName: string): number {
        let hash = 0;

        for (let i = 0; i < fullName.length; i++) {
            hash = fullName.charCodeAt(i) + ((hash << 5) - hash);
        }
        hash = Math.abs(hash);

        return hash;
    }

    static normalizeHash(hash: number, min: number, max: number): number {
        return Math.floor((hash % (max - min)) + min);
    }

    static generateHsl(name: string): number[] {
        const hash = this.getHashOfString(name);

        const h = this.normalizeHash(hash, 0, 360);
        const s = this.normalizeHash(hash, 50, 75);
        const l = this.normalizeHash(hash, 25, 60);

        return [h, s, l];
    }

    static hslToString(hsl: number[]): string {
        return `hsl(${hsl[0]}, ${hsl[1]}%, ${hsl[2]}%)`;
    }
}
