import { FormBuilder, Validators } from '@angular/forms';

export default class Utils {
    static tagsList: string[] = [
        'Architecture',
        'Arts',
        'Cars',
        'Celebrities',
        'Cooking',
        'Dancing',
        'Ecology',
        'Design',
        'History',
        'Fashion',
        'Medicine',
        'Technologies',
        'Pets',
        'Philosophy',
        'Photography',
        'Politics',
    ];

    static lessons = [
        {
            id: 1,
            imgPath: 'assets/lesson-mocks/Photo-4.png',
            videoId: 'xqAriI87lFU',
            title: 'The Real New Yorker’s Sandwich',
            time: '11.00',
            tutorAvatarPath: 'assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: 'assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet', 'biology'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: true,
        },
        {
            id: 2,
            imgPath: 'assets/lesson-mocks/Photo-5.png',
            videoId: 'xqAriI87lFU',
            title: 'The Diet That Helps Fight Climate Change. How to help?',
            time: '11.00',
            tutorAvatarPath: 'assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: 'assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: false,
        },
        {
            id: 3,
            imgPath: 'assets/lesson-mocks/Photo-2.png',
            videoId: 'xqAriI87lFU',
            title: 'How to measure extreme distances',
            time: '11.00',
            tutorAvatarPath: 'assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: 'assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet', 'biology'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: false,
        },
        {
            id: 4,
            imgPath: 'assets/lesson-mocks/Photo-3.png',
            videoId: 'xqAriI87lFU',
            title: 'What’s so great about the Great Lakes?',
            time: '11.00',
            tutorAvatarPath: 'assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: 'assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet', 'biology'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: false,
        },
        {
            id: 5,
            imgPath: 'assets/lesson-mocks/Photo.png',
            videoId: 'xqAriI87lFU',
            title: 'No That Easy',
            time: '11.00',
            tutorAvatarPath: 'assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: 'assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet', 'sport', 'biology'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: false,
        },
        {
            id: 6,
            imgPath: 'assets/lesson-mocks/Photo-1.png',
            videoId: 'xqAriI87lFU',
            title: 'Is It Better to Be Polite or Frank?',
            time: '11.00',
            tutorAvatarPath: 'assets/lesson-mocks/Photo )Patient).png',
            tutorFlagPath: 'assets/lesson-icons/canada-test-flag.svg',
            tutorName: 'Roger Vaccaro',
            topics: ['healthy', 'food', 'diet', 'sport', 'biology'],
            viewersCount: 38,
            level: 'B1',
            isDisabled: false,
        },
    ];

    static group(fb: FormBuilder) {
        return fb.group({
            name: ['', [
                Validators.required,
            ]],
            description: ['', [
                Validators.required,
            ]],
            date: ['', [
                Validators.required,
            ]],
            questions: ['', [
                Validators.required,
            ]],
            tags: ['', [
                Validators.required,
            ]],
        });
    }
}
