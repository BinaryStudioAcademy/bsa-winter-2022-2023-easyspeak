export const validationErrorMessage: { [id: string]: string } = {
    required: 'Field is required',
    maxlength: 'Value is too long',
    email: 'Not valid email format',
    minlength: 'Value is too short',
    name: 'Can contain latin letters and hyphen, min 2, max 25',
    pattern: 'Can contain latin letters, at least one lowercase and one uppercase, min 6, max 25',
    matchError: 'Not match',
    signInEmailNotFound: 'User with such email doesn’t exist',
    signInEmailLength: 'Min 3, max 50',
};
