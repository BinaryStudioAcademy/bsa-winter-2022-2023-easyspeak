import { Component, Input } from '@angular/core';
import { AuthService } from '@core/services/auth.service';
import { ColorGenerationUtils } from '@shared/utils/color.utils';

@Component({
    selector: 'app-avatar',
    templateUrl: './avatar.component.html',
    styleUrls: ['./avatar.component.sass'],
})
export class AvatarComponent {
    @Input() firstName: string;

    @Input() lastName: string;

    @Input() imagePath: string;

    @Input() imageSize: number;

    constructor(private authService: AuthService) {}

    getInitials(): string {
        if (!this.firstName || !this.lastName) {
            return 'NO';
        }

        return (this.firstName[0] + this.lastName[0]).toUpperCase();
    }

    getAvatarBackground(): string {
        const HSL = ColorGenerationUtils.generateHsl(this.getInitials());

        return ColorGenerationUtils.hslToString(HSL);
    }

    getAvatarImage(): string {
        if (this.imagePath && this.imagePath.match(/^man+/)) {
            return `assets/user-profile/${this.imagePath}.svg`;
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
