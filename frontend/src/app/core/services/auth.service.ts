import { Injectable, NgZone } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NotificationsHubService } from '@core/hubs/notifications-hub.service';
import { WebrtcHubService } from '@core/hubs/webrtc-hub.service';
import { HttpService } from '@core/services/http.service';
import { IUserShort } from '@shared/models/IUserShort';
import * as auth from 'firebase/auth';
import firebase from 'firebase/compat';
import { BehaviorSubject, defer, first, firstValueFrom, from, tap } from 'rxjs';

import { NotificationService } from 'src/app/services/notification.service';

import { UserService } from './user.service';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    user = new BehaviorSubject<IUserShort>({} as IUserShort);

    public userData$ = this.user.asObservable();

    setUser(userShort: IUserShort) {
        this.user.next(userShort);
    }

    constructor(
        private afs: AngularFirestore,
        private afAuth: AngularFireAuth,
        private router: Router,
        private ngZone: NgZone,
        private httpService: HttpService,
        public jwtHelper: JwtHelperService,
        private userService: UserService,
        private toastr: NotificationService,
        private webRtcHub: WebrtcHubService,
        private notificationsHub: NotificationsHubService,
    ) {
        this.afAuth.onIdTokenChanged(user => {
            if (user) {
                this.setAccessToken(user);
            }
        });
    }

    async handleUserCredential(userCredential: firebase.auth.UserCredential) {
        if (userCredential.user) {
            await this.setAccessToken(userCredential.user);

            this.webRtcHub.start().then(() => {
                this.webRtcHub.connect(userCredential.user?.email as string);
            });
        }
    }

    async signIn(email: string, password: string): Promise<void> {
        const userCredential = await this.afAuth.signInWithEmailAndPassword(email, password);

        await this.handleUserCredential(userCredential);

        try {
            await firstValueFrom(this.userService.getUser());
        } catch {
            await this.logout();
            throw new Error('User was incorrectly registered, please try another one');
        }
    }

    signUp(email: string, password: string) {
        return defer(() => this.afAuth
            .createUserWithEmailAndPassword(email, password))
            .pipe(
                first(),
                tap({
                    next: (userCredential) => {
                        from(this.handleUserCredential(userCredential));
                    },
                    error: (e) => { throw e; },
                }),
            );
    }

    private async setAccessToken(user: firebase.User): Promise<void> {
        const userIdToken = await user.getIdToken();

        localStorage.setItem('accessToken', userIdToken);
    }

    setLocalStorage(user: IUserShort) {
        localStorage.setItem('user', JSON.stringify(user));
        this.user.next(user);
    }

    loadUser() {
        this.userService.getUser().subscribe(
            (resp) => {
                const user = {
                    id: resp.id,
                    email: resp.email,
                    firstName: resp.firstName,
                    lastName: resp.lastName,
                    imagePath: resp.imagePath,
                    isAdmin: resp.isAdmin,
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
        const user: IUserShort = JSON.parse(localStorage.getItem('user') as string);

        this.webRtcHub.disconnectUser(user.email);

        this.notificationsHub.disconnectUser(user.email);

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

    async resetPassword(email: string) {
        await this.afAuth.sendPasswordResetEmail(email).catch((error) => {
            throw new Error(error.message);
        });
    }

    async confirmResetPassword(code: string, newPassword: string) {
        await this.afAuth.confirmPasswordReset(code, newPassword).catch((error) => {
            throw new Error(error.message);
        });
    }

    async saveNewPassword(oldPassword: string, newPassword: string) {
        const user = await this.afAuth.currentUser;

        if (user?.email) {
            await this.afAuth.signInWithEmailAndPassword(user.email, oldPassword)
                .then(async () => {
                    await auth.updatePassword(user, newPassword);
                })
                .catch((error) => {
                    throw new Error(error.message);
                });
        } else {
            throw new Error('User email not found!');
        }
    }
}
