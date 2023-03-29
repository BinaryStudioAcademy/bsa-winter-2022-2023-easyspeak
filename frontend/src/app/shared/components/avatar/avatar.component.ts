import { Component, Input, OnInit } from '@angular/core';
import { IUserInfo } from '@shared/models/IUserInfo';

@Component({
    selector: 'app-avatar',
    templateUrl: './avatar.component.html',
    styleUrls: ['./avatar.component.sass'],
})
export class AvatarComponent implements OnInit {
    @Input() size: number;

    userInfo: IUserInfo;

    ngOnInit(): void {
        const userSection = localStorage.getItem('user');

        if (userSection) {
            this.userInfo = JSON.parse(userSection);
        }
    }

    getInitials(): string {
        return this.userInfo.firstName[0] + this.userInfo.lastName[0];
    }

    getAvatarBackground(): string {
        const initials = this.getInitials().toUpperCase();
        const color1 = (initials.charCodeAt(0) % 8).toString();
        const color2 = (initials.charCodeAt(1) % 8).toString();
        const color3 = ((initials.charCodeAt(0) + initials.charCodeAt(1)) % 8).toString();

        return `#${color1}${color3}${color2}`;
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
