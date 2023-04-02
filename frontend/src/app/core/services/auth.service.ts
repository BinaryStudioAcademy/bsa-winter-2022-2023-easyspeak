import { Injectable, NgZone } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpService } from '@core/services/http.service';
import { UserShort } from '@shared/models/UserShort';
import * as auth from 'firebase/auth';
import firebase from 'firebase/compat';
import { ToastrService } from 'ngx-toastr';
import { firstValueFrom, Observable, of, Subject } from 'rxjs';

import { NotificationService } from 'src/app/services/notification.service';

import { UserService } from './user.service';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    user = new Subject<UserShort>();

    constructor(
        private afs: AngularFirestore,
        private afAuth: AngularFireAuth,
        private router: Router,
        private ngZone: NgZone,
        private httpService: HttpService,
        private toastrService: ToastrService,
        public jwtHelper: JwtHelperService,
        private userService: UserService,
        private toastr: NotificationService,
    ) {}

    async handleUserCredentialThenNavigatoTo(userCredential: firebase.auth.UserCredential, route: string) {
        if (userCredential.user) {
            await this.setAccessToken(userCredential.user).then(() => this.navigateTo(route));
        }
    }

    async signIn(email: string, password: string): Promise<void> {
        const userCredential = await this.afAuth.signInWithEmailAndPassword(email, password);

        await this.handleUserCredentialThenNavigatoTo(userCredential, '/timetable');

        try {
            await firstValueFrom(this.userService.getUser());
        } catch {
            await this.logout();
            throw new Error('User was incorrectly registered, please try another one');
        }
    }

    signUp(email: string, password: string) {
        return this.afAuth
            .createUserWithEmailAndPassword(email, password)
            .then(async (userCredential) => {
                await this.handleUserCredentialThenNavigatoTo(userCredential, '/topics');
            })
            .catch(() => {
                throw new Error('This email is already registered. Try another one');
            });
    }

    private async setAccessToken(user: firebase.User): Promise<void> {
        const userIdToken = await user.getIdToken();

        localStorage.setItem('accessToken', userIdToken);
    }

    setLocalStorage(user: UserShort) {
        localStorage.setItem('user', JSON.stringify(user));
        this.user.next(user);
        this.user.complete();
    }

    loadUser() {
        this.userService.getUser().subscribe(
            (resp) => {
                const user = {
                    firstName: resp.firstName,
                    lastName: resp.lastName,
                    imagePath: resp.imagePath,
                };

                this.setLocalStorage(user);
            },
            (err: Error) => {
                this.logout();
                this.toastr.showError(err.message, 'Error!');
            },
        );

        return this.user.asObservable();
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
