import { Component, Input } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { ColorGenerationUtils } from '@shared/utils/color.utils';

@Component({
    selector: 'app-avatar',
    templateUrl: './avatar.component.html',
    styleUrls: ['./avatar.component.sass'],
})
export class AvatarComponent {
    @Input() fullName: string;

    @Input() imagePath: string;

    constructor(private authService: AuthService) {}

    getInitials(): string {
        if (!this.fullName) {
            return 'NO';
        }
        const userName = this.fullName.split(' ');

        return (userName[0][0] + userName[1][0]).toUpperCase();
    }

    getAvatarBackground(): string {
        const HSL = ColorGenerationUtils.generateHsl(this.getInitials());

        return ColorGenerationUtils.hslToString(HSL);
    }

    getAvatarImage(): string {
        if (this.imagePath && this.imagePath.match(/^predefinedavatar-\d+/)) {
            return `assets/avatars/${this.imagePath}`;
        }

        return this.imagePath;
    }

    getAvatarSrc(): string {
        if (!this.imagePath) {
            return '';
        }

        return this.getAvatarImage();
    }
}
