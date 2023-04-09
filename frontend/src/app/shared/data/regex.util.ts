export const passFormatRegex = '^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\\d@$!%*?&\\.]{6,}$';
export const emailFormatRegex = /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/;
export const passwordRegex = '^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\\d@$!%*?&\\.]{6,25}$';
export const emailRegex = '^([\\w-]+(\\.{1}[\\w-]+|[\\w-]*))@([0-9a-zA-Z]+(\\.{1}[\\da-zA-Z]+|[\\da-zA-Z]*))$';
export const nameFormatRegex = '^([a-zA-Z-]){2,25}$';
export const youtubeVideoLinkRegex = /(?:youtube(?:-nocookie)?\.com\/(?:[^/\n\s]+\/\S+\/|(?:v|vi|user)\/|\S*?[?&]v=)|youtu\.be\/)([a-zA-Z0-9_-]{11})/;
