import { AfterContentChecked, AfterViewInit, ChangeDetectorRef, Component, Input } from '@angular/core';
import { ColorGenerationUtils } from '@shared/utils/color.utils';

@Component({
    selector: 'app-avatar',
    templateUrl: './avatar.component.html',
    styleUrls: ['./avatar.component.sass'],
})
export class AvatarComponent implements AfterViewInit, AfterContentChecked {
    @Input() firstName: string;

    @Input() lastName: string;

    @Input() imagePath: string;

    @Input() imageSize: number;

    private avatarBackgroundColor = '#61D4F6';

    avatarBackground: string;

    paddingAvatar: string;

    imgFlexSize: number;

    constructor(private changeDetector: ChangeDetectorRef) {}

    ngAfterViewInit() {
        if (!this.imagePath) {
            this.getAvatarBackground();
        }
    }

    ngAfterContentChecked() {
        this.avatarBackground = this.avatarBackgroundColor;

        if (this.isEmojiAvatar()) {
            this.imgFlexSize = this.imgFlexSize > 37 ? this.imageSize - 20 : this.imageSize - 10;
        }

        this.changeDetector.detectChanges();
    }

    getInitials(): string {
        if (!this.firstName || !this.lastName) {
            return 'NO';
        }

        return (this.firstName[0] + this.lastName[0]).toUpperCase();
    }

    getAvatarBackground() {
        const HSL = ColorGenerationUtils.generateHsl(this.getInitials());

        this.avatarBackground = ColorGenerationUtils.hslToString(HSL);
    }

    getAvatarImage(): string {
        if (this.isEmojiAvatar()) {
            this.avatarBackground = this.avatarBackgroundColor;

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

    private isEmojiAvatar = () => this.imagePath && this.imagePath.match(/^man+/);
}
