export const validationErrorMessage: { [id: string]: string } = {
    required: 'Field is required',
    maxlength: 'Value is too long',
    email: 'Not valid email adress',
    minlength: 'Value is too short',
    name: 'Can contain latin letters and hyphen, min 2, max 25',
    pattern: 'Should have at least one small and one capital letter',
    matchError: 'Not match',
    signInEmailNotFound: 'User with such email doesn’t exist',
    signInEmailLength: 'Min 3, max 50',
    signInPasswordLength: 'Min 6, max 25',
    singInPasswordIncorrect: 'Incorrect password',
};
