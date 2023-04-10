// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
    production: false,
    coreUrl: 'http://localhost:5050',
    notifierUrl: 'http://localhost:5070',
    communicatorUrl: 'https://localhost:5080',
    iceServers: [{ urls: 'stun:stun.1.google.com:19302' }, { urls: 'stun:stun1.l.google.com:19302' }],
    firebaseConfig: {
        apiKey: 'AIzaSyAA-TlYaZVolTEKFa2lXEVHYYH5GvYS9oI',
        authDomain: 'easy-meets-id-01.firebaseapp.com',
        projectId: 'easy-meets-id-01',
        storageBucket: 'easy-meets-id-01.appspot.com',
        messagingSenderId: '286412559703',
        appId: '1:286412559703:web:f5b1b617bf593e71959a12',
    },
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
