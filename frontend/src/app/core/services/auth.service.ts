import { Injectable, NgZone } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpService } from '@core/services/http.service';
import { IUserInfo } from '@shared/models/IUserInfo';
import * as auth from 'firebase/auth';
import firebase from 'firebase/compat';
import { from } from 'rxjs';

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
        public jwtHelper: JwtHelperService,
        private userService: UserService,
    ) {}

    signIn(email: string, password: string) {
        return this.afAuth.signInWithEmailAndPassword(email, password).then((userCredential) => {
            if (userCredential.user) {
                this.setAccessToken(userCredential.user);
                this.navigateTo('/timetable');
            }
        });
    }

    signUp(email: string, password: string) {
        return this.afAuth.createUserWithEmailAndPassword(email, password).then((userCredential) => {
            if (userCredential.user) {
                this.setAccessToken(userCredential.user);
                this.navigateTo('/timetable');
            }
        });
    }

    private setAccessToken(user: firebase.User) {
        from(user.getIdToken()).subscribe((token) => localStorage.setItem('accessToken', token));
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
}
