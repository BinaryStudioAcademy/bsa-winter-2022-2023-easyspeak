import { Component, Input, OnInit } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { IUserInfo } from '@shared/models/IUserInfo';
import { ColorGenerationUtils } from '@shared/utils/color.utils';

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
            this.userInfo = userSection;
        }
    }

    getInitials(): string {
        return (this.userInfo.firstName[0] + this.userInfo.lastName[0]).toUpperCase();
    }

    getAvatarBackground(): string {
        const HSL = ColorGenerationUtils.generateHsl(this.getInitials());

        return ColorGenerationUtils.hslToString(HSL);
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
