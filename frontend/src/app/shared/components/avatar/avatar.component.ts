import { Component, Input, OnInit } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { IUserInfo } from '@shared/models/IUserInfo';

@Component({
    selector: 'app-avatar',
    templateUrl: './avatar.component.html',
    styleUrls: ['./avatar.component.sass'],
})
export class AvatarComponent implements OnInit {
    @Input() size: number;

    userInfo: IUserInfo;

    constructor(private authService: AuthService) {}

    ngOnInit(): void {
        const userSection = this.authService.getUserSection();

        if (userSection) {
            this.userInfo = JSON.parse(userSection);
        }
    }

    getInitials(): string {
        return (this.userInfo.firstName[0] + this.userInfo.lastName[0]).toUpperCase();
    }

    getAvatarBackground(): string {
        const HSL = this.generateHsl(this.getInitials());

        return this.hslToString(HSL);
    }

    getHashOfString(fullName: string): number {
        let hash = 0;

        for (let i = 0; i < fullName.length; i++) {
            hash = fullName.charCodeAt(i) + ((hash << 5) - hash);
        }
        hash = Math.abs(hash);

        return hash;
    }

    normalizeHash(hash: number, min: number, max: number): number {
        return Math.floor((hash % (max - min)) + min);
    }

    generateHsl(name: string): number[] {
        const hash = this.getHashOfString(name);

        const h = this.normalizeHash(hash, 0, 360);
        const s = this.normalizeHash(hash, 50, 75);
        const l = this.normalizeHash(hash, 25, 60);

        return [h, s, l];
    }

    hslToString(hsl: number[]): string {
        return `hsl(${hsl[0]}, ${hsl[1]}%, ${hsl[2]}%)`;
    }

    getAvatarImage(): string {
        if (this.userInfo.imagePath && this.userInfo.imagePath.match(/^predefinedavatar-\d+/)) {
            return `assets/avatars/${this.userInfo.imagePath}`;
        }

        return this.userInfo.imagePath;
    }

    getAvatarSrc(): string {
        if (!this.userInfo.imagePath) {
            return '';
        }

        return this.getAvatarImage();
    }
}
