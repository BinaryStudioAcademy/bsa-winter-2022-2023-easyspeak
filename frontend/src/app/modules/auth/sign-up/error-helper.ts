export const validationErrorMessage: { [id: string]: string } = {
    required: 'Field is required',
    maxlength: 'Value is too long',
    //email: 'Not valid email format',
    minlength: 'Value is too short',
    name: 'Can contain latin letters and hyphen, min 2, max 25',
    pattern: 'Should have at least one small and one capital letter',
    matchError: 'Not match',
};
