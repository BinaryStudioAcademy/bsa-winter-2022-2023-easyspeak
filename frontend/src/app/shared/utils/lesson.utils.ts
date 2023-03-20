import { FormBuilder, Validators } from "@angular/forms";

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
