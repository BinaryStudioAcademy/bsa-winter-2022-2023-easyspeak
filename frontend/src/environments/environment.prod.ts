export const environment = {
    production: true,
    coreUrl: '/api',
    notifierUrl: '/notifier',
    communicatorUrl: '/communicator',
    iceServers: [
        { urls: 'stun:stun.1.google.com:19302' },
        { urls: 'stun:stun1.l.google.com:19302' },
    ],
    firebaseConfig: {
        apiKey: 'AIzaSyAA-TlYaZVolTEKFa2lXEVHYYH5GvYS9oI',
        authDomain: 'easy-meets-id-01.firebaseapp.com',
        projectId: 'easy-meets-id-01',
        storageBucket: 'easy-meets-id-01.appspot.com',
        messagingSenderId: '286412559703',
        appId: '1:286412559703:web:f5b1b617bf593e71959a12',
    },
};
