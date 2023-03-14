import { Injectable, NgZone } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore, AngularFirestoreDocument } from '@angular/fire/compat/firestore';
import { Router } from '@angular/router';
import { HttpService } from '@core/services/http.service';
import { IUser } from '@shared/models/IUser';
import * as auth from 'firebase/auth';
import firebase from 'firebase/compat';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    private userData: firebase.User;

    private url = '';

    constructor(
        public afs: AngularFirestore,
        public afAuth: AngularFireAuth,
        public router: Router,
        public ngZone: NgZone,
        public httpService: HttpService,
    ) {
        this.afAuth.authState.subscribe((user) => {
            if (user) {
                this.userData = user;
                localStorage.setItem('user', JSON.stringify(this.userData));
                JSON.parse(localStorage.getItem('user')!);
            } else {
                localStorage.setItem('user', 'null');
                JSON.parse(localStorage.getItem('user')!);
            }
        });
    }

    SignIn(email: string, password: string) {
        return this.afAuth
            .signInWithEmailAndPassword(email, password)
            .then((result) => {
                this.SetUserData(result.user);
                this.afAuth.authState.subscribe((user) => {
                    if (user) {
                        this.router.navigate(['']);
                    }
                });
            })
            .catch((error) => {
                window.alert(error.message);
            });
    }

    SignUp(email: string, password: string) {
        return this.afAuth
            .createUserWithEmailAndPassword(email, password)
            .then((result) => {
                this.SetUserData(result.user);
                this.httpService.post<any>(this.url, result.user);
            })
            .catch((error) => {
                window.alert(error.message);
            });
    }

    get isLoggedIn(): boolean {
        const user = JSON.parse(localStorage.getItem('user')!);

        return user !== null;
    }

    FacebookAuth() {
        return this.AuthLogin(new auth.FacebookAuthProvider()).then((res: any) => {
            this.router.navigate(['']);
        });
    }

    GoogleAuth() {
        return this.AuthLogin(new auth.GoogleAuthProvider()).then((res: any) => {
            this.router.navigate(['']);
        });
    }

    AuthLogin(provider: any) {
        return this.afAuth
            .signInWithPopup(provider)
            .then((result) => {
                this.router.navigate(['']);
                this.SetUserData(result.user);
            })
            .catch((error) => {
                window.alert(error);
            });
    }

    SetUserData(user: any) {
        const userRef: AngularFirestoreDocument<any> = this.afs.doc(
            `users/${user.uid}`,
        );
        const userData: IUser = {
            uid: user.uid,
            country: user.country,
            language: user.language,
            timezone: user.timezone,
            firstName: user.firstName,
            lastName: user.lastName,
            age: user.age,
            email: user.email,
            imagePath: user.imagePath,
            sex: user.sex,
            languageLevel: user.languageLevel,
            status: user.status,
            isSubscribed: user.isSubscribed,
            isBanned: user.isBanned,
        };

        return userRef.set(userData, {
            merge: true,
        });
    }
}
