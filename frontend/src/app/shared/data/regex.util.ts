export const passFormatRegex = '^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\\d@$!%*?&\\.]{6,25}$';
export const emailFormatRegex = /^([\\w-]+(\\.[\\w-]+|[\\w-]*))@([0-9a-zA-Z]+(\\.[\\da-zA-Z]+|[\\da-zA-Z]*))$/;
export const nameFormatRegex = '^([a-zA-Z-]){2,25}$';
export const youtubeVideoLinkRegex = /(?:youtube(?:-nocookie)?\.com\/(?:[^/\n\s]+\/\S+\/|(?:v|vi|user)\/|\S*?[?&]v=)|youtu\.be\/)([a-zA-Z0-9_-]{11})/;
