import { Injectable, NgZone } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpService } from '@core/services/http.service';
import { IUserInfo } from '@shared/models/IUserInfo';
import * as auth from 'firebase/auth';
import firebase from 'firebase/compat';
import { ToastrService } from 'ngx-toastr';
import { from, firstValueFrom, Observable, of } from 'rxjs';

import { UserService } from './user.service';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    constructor(
        private afs: AngularFirestore,
        private afAuth: AngularFireAuth,
        private router: Router,
        private ngZone: NgZone,
        private httpService: HttpService,
        private toastrService: ToastrService,
        public jwtHelper: JwtHelperService,
        private userService: UserService,
    ) {}

    async signIn(email: string, password: string): Promise<void> {
        const userCredential = await this.afAuth.signInWithEmailAndPassword(email, password);

        if (userCredential.user) {
            await this.setAccessToken(userCredential.user);
        }

        try {
            await firstValueFrom(this.userService.getUser());
        } catch {
            await this.logout();
            throw new Error('User was incorrectly registered, please try another one');
        }
    }

    signUp(email: string, password: string) {
        return this.afAuth.createUserWithEmailAndPassword(email, password).then((userCredential) => {
            if (userCredential.user) {
                this.setAccessToken(userCredential.user);
            }
        });
    }

    private async setAccessToken(user: firebase.User): Promise<void> {
        const userIdToken = await user.getIdToken();

        localStorage.setItem('accessToken', userIdToken);
    }

    public setUserSection() {
        this.userService.getUser().subscribe((resp) => {
            localStorage.setItem('user', JSON.stringify(resp));
        });
    }

    public getUserSection() {
        const userSection = localStorage.getItem('user');

        if (!userSection) {
            return null;
        }

        const userInfo: IUserInfo = JSON.parse(userSection);

        return userInfo;
    }

    private navigateTo(route: string) {
        this.afAuth.authState.subscribe((user) => {
            if (user) {
                this.router.navigate([route]);
            }
        });
    }

    public isAuthenticated(): boolean {
        const token = localStorage.getItem('accessToken');

        return !this.jwtHelper.isTokenExpired(token);
    }

    logout(): Promise<void> {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('user');

        this.router.navigate(['auth/sign-in']);

        return this.afAuth.signOut();
    }

    facebookAuth() {
        return this.authLogin(new auth.FacebookAuthProvider()).then(() => {
            this.router.navigate(['']);
        });
    }

    googleAuth() {
        return this.authLogin(new auth.GoogleAuthProvider()).then(() => {
            this.router.navigate(['']);
        });
    }

    authLogin(provider: auth.AuthProvider) {
        return this.afAuth.signInWithPopup(provider).then(() => {
            this.router.navigate(['']);
        });
    }

    async resetPassword(email: string): Promise<Observable<boolean>> {
        try {
            await this.afAuth.sendPasswordResetEmail(email);

            return of(true);
        } catch (errorReset) {
            const errorMessage = (errorReset as Error).message;

            this.toastrService.error(errorMessage, 'Error');

            return of(false);
        }
    }

    async confirmResetPassword(code: string, newPassword: string) {
        try {
            await this.afAuth.confirmPasswordReset(code, newPassword);

            return true;
        } catch (errorConfirm: unknown) {
            const errorMessage = (errorConfirm as Error).message;

            this.toastrService.error(errorMessage, 'Error');

            return false;
        }
    }
}
