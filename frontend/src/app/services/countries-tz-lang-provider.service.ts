import { Injectable } from '@angular/core';
import { rawTimeZones } from '@vvo/tzdb';
import languagesLib from 'iso-639-1';
import countriesLib from 'iso-3166-1';

@Injectable({
    providedIn: 'root',
})
export class CountriesTzLangProviderService {
    getCountriesList() {
        const countries = countriesLib.all().map((country) => ({
            name: country.country,
            flag: `https://flagicons.lipis.dev/flags/1x1/${country.alpha2.toLowerCase()}.svg`,
            flag_rectangular: `https://flagicons.lipis.dev/flags/4x3/${country.alpha2.toLowerCase()}.svg`,
        }));

        return countries;
    }

    getTimeZonesList() {
        const timezones = rawTimeZones.map((timezone) => ({
            name: timezone.name,
            offsetInMinutes: timezone.rawOffsetInMinutes, //Subtract this value before saving time to DB, and add it back when displaying
        }));

        return timezones;
    }

    getLanguagesList() {
        const languages = languagesLib.getAllNames();

        return languages;
    }
}
