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
            } else {
                localStorage.removeItem('user');
            }
            this.getUserData();
        }).unsubscribe();
    }

    SignIn(email: string, password: string) {
        return this.afAuth
            .signInWithEmailAndPassword(email, password)
            .then((result) => {
                this.setUserData(result.user);
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
                this.setUserData(result.user);
                this.httpService.post<firebase.User | null>(this.url, result.user);
            })
            .catch((error) => {
                window.alert(error.message);
            });
    }

    get isLoggedIn(): boolean {
        const user = this.getUserData();

        return !!user;
    }

    FacebookAuth() {
        return this.AuthLogin(new auth.FacebookAuthProvider()).then((res: void) => {
            this.router.navigate(['']);
        });
    }

    GoogleAuth() {
        return this.AuthLogin(new auth.GoogleAuthProvider()).then((res: void) => {
            this.router.navigate(['']);
        });
    }

    AuthLogin(provider: auth.AuthProvider) {
        return this.afAuth
            .signInWithPopup(provider)
            .then((result) => {
                this.router.navigate(['']);
                this.setUserData(result.user);
            })
            .catch((error) => {
                window.alert(error);
            });
    }

    setUserData(user: any) {
        const userRef: AngularFirestoreDocument = this.afs.doc(
            `users/${user.uid}`,
        );
        const userData: IUser = {
            firstName: user.firstName,
            lastName: user.lastName,
            email: user.email,
        };

        return userRef.set(userData, {
            merge: true,
        });
    }

    getUserData(): IUser {
        return JSON.parse(localStorage.getItem('user')!);
    }
}
