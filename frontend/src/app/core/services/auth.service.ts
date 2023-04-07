import { Injectable, NgZone } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpService } from '@core/services/http.service';
import { IUserShort } from '@shared/models/IUserShort';
import * as auth from 'firebase/auth';
import firebase from 'firebase/compat';
import { defer, first, firstValueFrom, from, Subject, tap } from 'rxjs';

import { NotificationService } from 'src/app/services/notification.service';

import { UserService } from './user.service';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    user = new Subject<IUserShort>();

    constructor(
        private afs: AngularFirestore,
        private afAuth: AngularFireAuth,
        private router: Router,
        private ngZone: NgZone,
        private httpService: HttpService,
        public jwtHelper: JwtHelperService,
        private userService: UserService,
        private toastr: NotificationService,
    ) {}

    async handleUserCredential(userCredential: firebase.auth.UserCredential) {
        if (userCredential.user) {
            await this.setAccessToken(userCredential.user);
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
                    error: () => { throw new Error('This email is already registered. Try another one'); },
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
        this.user.complete();
    }

    loadUser() {
        this.userService.getUser().subscribe(
            (resp) => {
                const user = {
                    id: resp.id,
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
        await this.afAuth.sendPasswordResetEmail(email)
            .catch((error) => {
                throw new Error(error.message);
            });
    }

    async confirmResetPassword(code: string, newPassword: string) {
        await this.afAuth.confirmPasswordReset(code, newPassword)
            .catch((error) => {
                throw new Error(error.message);
            });
    }
}
