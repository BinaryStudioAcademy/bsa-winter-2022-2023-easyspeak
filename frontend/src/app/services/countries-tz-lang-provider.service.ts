import { Injectable } from '@angular/core';
import countriesLib from 'iso-3166-1';

@Injectable({
    providedIn: 'root',
})
export class CountriesTzLangProviderService {
    getCountriesList() {
        const countries = countriesLib.all().map((country) => ({
            name: country.country,
            flag: `https://flagicons.lipis.dev/flags/1x1/${country.alpha2.toLowerCase()}.svg`,
        }));

        return countries;
    }
}
