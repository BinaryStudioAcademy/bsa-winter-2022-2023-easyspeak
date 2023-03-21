import { Injectable, NgZone } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Router } from '@angular/router';
import { HttpService } from '@core/services/http.service';
import { INewUser } from '@shared/models/INewUser';
import { IUser } from '@shared/models/IUser';
import * as auth from 'firebase/auth';
import firebase from 'firebase/compat';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    private userData: firebase.User;

    private refreshToken: string;

    private url = '';

    constructor(
        private afs: AngularFirestore,
        private afAuth: AngularFireAuth,
        private router: Router,
        private ngZone: NgZone,
        private httpService: HttpService,
    ) {
        this.afAuth.authState
            .subscribe((user) => {
                if (user) {
                    this.userData = user;
                    localStorage.setItem('user', JSON.stringify(this.userData));
                    localStorage.setItem('refreshToken', JSON.stringify(this.userData.refreshToken));
                } else {
                    localStorage.removeItem('user');
                    localStorage.removeItem('refreshToken');
                }
                this.getUserData();
            })
            .unsubscribe();
    }

    signIn(email: string, password: string) {
        const result = this.afAuth.signInWithEmailAndPassword(email, password);
        // .then(() => {
        //     this.afAuth.authState.subscribe((user) => {
        //         if (user) {
        //             this.router.navigate(['']);
        //         }
        //     });
        // })
        // .catch((error) => {
        //     // Handle Errors here.
        //     const errorCode = error.code;
        //     const errorMessage = error.message;

        //     if (errorCode === 'auth/wrong-password') {
        //         alert('Wrong password.');
        //     } else {
        //         alert(errorMessage);
        //     }
        //     console.log(error);
        // });
        console.log(result);
    }

    signUp(user: INewUser, password: string) {
        const result = this.afAuth
            .createUserWithEmailAndPassword(user.email, password)
            .then((result) => this.httpService.post<firebase.User | null>(this.url, result.user));
    }

    get isLoggedIn(): boolean {
        const user = this.getUserData();

        return !!user;
    }

    logout(): Promise<void> {
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

    getUserData(): IUser {
        return JSON.parse(localStorage.getItem('user')!);
    }
}
