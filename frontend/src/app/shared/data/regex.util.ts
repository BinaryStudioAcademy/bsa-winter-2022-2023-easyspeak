export const passFormatRegex = '^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\\d@$!%*?&\\.]{6,}$';
export const emailFormatRegex = '^[a-zA-Z0-9-\\_\\.]+@[a-zA-Z0-9\\.]+$';//'^[a-zA-Z0-9_-\\.]{1,}@[a-zA-Z0-9\\.]{1,}$';
export const nameFormatRegex = '^([a-zA-Z-]){2,25}$';
export const youtubeVideoLinkRegex = /(?:youtube(?:-nocookie)?\.com\/(?:[^/\n\s]+\/\S+\/|(?:v|vi|user)\/|\S*?[?&]v=)|youtu\.be\/)([a-zA-Z0-9_-]{11})/;
