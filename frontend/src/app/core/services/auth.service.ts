import { Injectable, NgZone } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpService } from '@core/services/http.service';
import { ILocalStorageUser } from '@shared/models/ILocalStorageUser';
import * as auth from 'firebase/auth';
import firebase from 'firebase/compat';
import { firstValueFrom, Subject } from 'rxjs';

import { NotificationService } from 'src/app/services/notification.service';

import { UserService } from './user.service';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    user = new Subject<ILocalStorageUser>();

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

    setLocalStorage(user: ILocalStorageUser) {
        localStorage.setItem('user', JSON.stringify(user));
        this.user.next(user);
        this.user.complete();
    }

    public setUserSection() {
        this.userService.getUser().subscribe(
            {
                next: (response) => {
                    const user: ILocalStorageUser = {
                        firstName: response.firstName,
                        lastName: response.lastName,
                        imagePath: response.imagePath,
                    };

                    this.setLocalStorage(user);
                },
                error: (error) => {
                    this.logout();
                    this.toastr.showError(error.message, 'Error!');
                },
            },
        );

        return this.user.asObservable();
    }

    public getUserSection() {
        const userSection: string = localStorage.getItem('user') as string;

        const userInfo: ILocalStorageUser = JSON.parse(userSection);

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
}
