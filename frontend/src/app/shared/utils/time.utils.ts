export class TimeUtils {
    static addTimeOffset(date: string): string {
        const offset = new Date().getTimezoneOffset();
        const dateObject = new Date(date);

        dateObject.setMinutes(dateObject.getMinutes() - offset);

        return dateObject.toString();
    }
}
