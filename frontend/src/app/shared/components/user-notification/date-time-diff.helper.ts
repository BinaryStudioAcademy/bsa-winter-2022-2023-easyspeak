import * as moment from 'moment';

enum timeSpan {
    minute = 1,
    hour = 60,
    day = 1440,
    week = 10080,
    month = 43200,
}

export const getTimeDiff = (date: Date): string => {
    const momentDate = moment(date);

    const diffInMinutes = moment().diff(momentDate, 'minutes');

    if (diffInMinutes < timeSpan.minute) {
        return 'Just now';
    }
    if (diffInMinutes < timeSpan.hour) {
        return `${diffInMinutes} minutes ago`;
    }
    if (diffInMinutes < timeSpan.day) {
        const diffInHours = moment().diff(momentDate, 'hours');

        return `${diffInHours} hours ago`;
    }
    if (diffInMinutes < timeSpan.week) {
        const diffInDays = moment().diff(momentDate, 'days');

        return `${diffInDays} days ago`;
    } if (diffInMinutes < timeSpan.month) {
        const diffInWeeks = moment().diff(momentDate, 'weeks');

        return `${diffInWeeks} weeks ago`;
    }

    const diffInMonths = moment().diff(momentDate, 'months');

    return `${diffInMonths} months ago`;
};
