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

    static timesList: string[] = [
        '8.00',
        '8.30',
        '9.00',
        '9.30',
        '10.00',
        '10.30',
        '11.00',
        '11.30',
        '12.00',
        '12.30',
        '13.00',
        '13.30',
        '14.00',
        '14.30',
        '15.00',
        '15.30',
        '16.00',
        '16.30',
        '17.00',
        '17.30',
        '18.00',
        '18.30',
        '19.00',
        '19.30',
        '20.00',
    ];

    static levelsList: string[] = [
        'B1',
        'B2',
        'C1',
        'C2',
    ];

    static group(fb: FormBuilder) {
        return fb.group({
            name: ['', [Validators.required]],
            description: ['', [Validators.required]],
            date: ['', [Validators.required]],
            questions: ['', [Validators.required]],
            tags: ['', [Validators.required]],
            videoLink: ['', [Validators.required]],
            studentsCount: ['', [Validators.required]],
            meetLink: ['', [Validators.required]],
        });
    }
}
