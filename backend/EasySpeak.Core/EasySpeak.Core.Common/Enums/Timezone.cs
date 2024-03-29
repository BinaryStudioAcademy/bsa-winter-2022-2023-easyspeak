﻿using System.ComponentModel;

namespace EasySpeak.Core.Common.Enums;

public enum Timezone
{
    [Description("acific/Niue")] Niue = 1,
    [Description("Pacific/Midway")] Midway,
    [Description("Pacific/Pago_Pago")] PagoPogo,
    [Description("Pacific/Rarotonga")] Rarotonga,
    [Description("America/Adak")] Adak,
    [Description("Pacific/Honolulu")] Honolulu,
    [Description("Pacific/Tahiti")] Tahiti,
    [Description("Pacific/Marquesas")] Marqueses,
    [Description("America/Anchorage")] Anchorage,
    [Description("Pacific/Gambier")] Gambier,
    [Description("America/Los_Angeles")] LosAngeles,
    [Description("America/Tijuana")] Tijuana,
    [Description("America/Vancouver")] Vancouver,
    [Description("Pacific/Pitcairn")] Pitcairn,
    [Description("America/Hermosillo")] Hermosillo,
    [Description("America/Edmonton")] Edmonton,
    [Description("America/Ciudad_Juarez")] CiudadJuarez,
    [Description("America/Denver")] Danver,
    [Description("America/Phoenix")] Pheonix,
    [Description("America/Whitehorse")] Whitehorse,
    [Description("America/Belize")] Belize,
    [Description("America/Chicago")] Chicago,
    [Description("America/Guatemala")] Guatemala,
    [Description("America/Managua")] Managua,
    [Description("America/Matamoros")] Matamoros,
    [Description("America/Costa_Rica")] CostaRica,
    [Description("America/El_Salvador")] Salvador,
    [Description("America/Regina")] Regina,
    [Description("America/Tegucigalpa")] Tequcigalpa,
    [Description("America/Winnipeg")] Winnipeg,
    [Description("Pacific/Easter")] Easter,
    [Description("Pacific/Galapagos")] Galapagos,
    [Description("America/Rio_Branco")] RioBlanco,
    [Description("America/Bogota")] Bogota,
    [Description("America/Havana")] Havana,
    [Description("America/Atikokan")] Atikotan,
    [Description("America/Cancun")] Cancun,
    [Description("America/Grand_Turk")] GrandTurk,
    [Description("America/Cayman")] Cayman,
    [Description("America/Jamaica")] Jamaica,
    [Description("America/Nassau")] Nassau,
    [Description("America/New_York")] NewYork,
    [Description("America/Panama")] Panama,
    [Description("America/Port-au-Prince")] Prince,
    [Description("America/Toronto")] Toronto,
    [Description("America/Guayaquil")] Guayaquil,
    [Description("America/Lima")] Lima,
    [Description("America/Manaus")] Manus,
    [Description("America/St_Kitts")] StKitts,
    [Description("America/Blanc-Sablon")] BlancSablon,
    [Description("America/Montserrat")] MsMonseratt,
    [Description("America/Barbados")] Barbados,
    [Description("America/St_Lucia")] Lucia,
    [Description("America/Port_of_Spain")] PortOfSpain,
    [Description("America/Martinique")] Martinique,
    [Description("America/St_Barthelemy")] StBarthelemy,
    [Description("America/Halifax")] Halifax,
    [Description("Atlantic/Bermuda")] Bermuda,
    [Description("America/St_Vincent")] Vincent,
    [Description("America/Kralendijk")] Kralendijk,
    [Description("America/Guadeloupe")] Guad,
    [Description("America/Marigot")] Marigot,
    [Description("America/Aruba")] Aruba,
    [Description("America/Lower_Princes")] LowerPrinces,
    [Description("America/Tortola")] Tortola,
    [Description("America/Dominica")] Dominicana,
    [Description("America/St_Thomas")] StTomas,
    [Description("America/Grenada")] Grenada,
    [Description("America/Antigua")] Antigua,
    [Description("America/Puerto_Rico")] PuertoRico,
    [Description("America/Santo_Domingo")] SantoDomingo,
    [Description("America/Anguilla")] Anguilla,
    [Description("America/Thule")] Thile,
    [Description("America/Curacao")] Curacao,
    [Description("America/La_Paz")] LaPaz,
    [Description("America/Santiago")] Santiago,
    [Description("America/Guyana")] Guyana,
    [Description("America/Asuncion")] Asuncion,
    [Description("America/Caracas")] Caracas,
    [Description("America/St_Johns")] StJohns,
    [Description("America/Argentina/Buenos_Aires")] BuenosAires,
    [Description("America/Sao_Paulo")] SanPaulo,
    [Description("Antarctica/Palmer")] Palmer,
    [Description("America/Punta_Arenas")] PuntaArenas,
    [Description("Atlantic/Stanley")] Stanley,
    [Description("America/Cayenne")] Cayenne,
    [Description("America/Miquelon")] Miquelon,
    [Description("America/Paramaribo")] Paramaribo,
    [Description("America/Montevideo")] Montevideo,
    [Description("America/Nuuk")] Nuuk,
    [Description("America/Noronha")] Noronha,
    [Description("Atlantic/South_Georgia")] SouthGeorgia,
    [Description("Atlantic/Azores")] Azores,
    [Description("Atlantic/Cape_Verd")] CapeVerd,
    [Description("America/Scoresbysund")] Scoresbysund,
    [Description("Africa/Abidjan")] Abidjan,
    [Description("Africa/Accra")] Accra,
    [Description("Africa/Bamako")] Bamako,
    [Description("Africa/Bissau")] Bissau,
    [Description("Africa/Conakry")] Conakry,
    [Description("Africa/Dakar")] Dakar,
    [Description("America/Danmarkshavn")] Danmarkshavn,
    [Description("Europe/Isle_of_Man")] IsleOfMan,
    [Description("Europe/Dublin")] Dublin,
    [Description("Africa/Freetown")] Freetown,
    [Description("Atlantic/St_Helena")] StHelena,
    [Description("Europe/London")] London,
    [Description("Africa/Monrovia")] Monrovia,
    [Description("Africa/Nouakchott")] Nouakchott,
    [Description("Africa/Ouagadougou")] Ouagadougou,
    [Description("Atlantic/Reykjavik")] Reykjavik,
    [Description("Europe/Jersey")] Jersey,
    [Description("Europe/Guernsey'")] Guernsey,
    [Description("Africa/Banjul")] Banjul,
    [Description("Africa/Sao_Tome")] SaoTome,
    [Description("Antarctica/Troll")] Troll,
    [Description("Africa/Casablanca")] Casablanca,
    [Description("Africa/El_Aaiun")] ElAaiun,
    [Description("Atlantic/Canary")] Canary,
    [Description("Europe/Lisbon")] Lisabon,
    [Description("Atlantic/Faroe")] Faroe,
    [Description("Africa/Windhoek")] Windhoek,
    [Description("Africa/Algiers")] Algiers,
    [Description("Europe/Amsterdam")] Amsterdam,
    [Description("Europe/Andorra")] Andorra,
    [Description("Europe/Belgrade")] Belgrade,
    [Description("Europe/Berlin")] Berlin,
    [Description("Europe/Bratislava")] Bratislava,
    [Description("Europe/Brussels")] Brussels,
    [Description("Europe/Budapest")] Budapest,
    [Description("Europe/Copenhagen")] Copenhagen,
    [Description("Europe/Gibraltar")] Gibraltar,
    [Description("Europe/Ljubljana")] Ljubljana,
    [Description("Arctic/Longyearbyen")] Longyearbyen,
    [Description("Europe/Luxembourg")] Luxembourg,
    [Description("Europe/Madrid")] Madrid,
    [Description("Europe/Monaco")] Monaco,
    [Description("Europe/Oslo")] Oslo,
    [Description("Europe/Paris")] Paris,
    [Description("Europe/Podgorica")] Podgorica,
    [Description("Europe/Prague")] Prague,
    [Description("Europe/Rome")] Rome,
    [Description("Europe/San_Marino")] SanMarino,
    [Description("Europe/Malta")] Malta,
    [Description("Europe/Sarajevo")] Sarajevo,
    [Description("Europe/Skopje")] Skopje,
    [Description("Europe/Stockholm")] Stockholm,
    [Description("Europe/Tirane")] Tirane,
    [Description("Africa/Tunis")] Tunis,
    [Description("Europe/Vaduz")] Vaduz,
    [Description("Europe/Vatican")] Vatican,
    [Description("Europe/Vienna")] Vienna,
    [Description("Europe/Warsaw")] Warsaw,
    [Description("Europe/Zagreb")] Zagreb,
    [Description("Europe/Zurich")] Zurich,
    [Description("Africa/Bangui")] Bangui,
    [Description("Africa/Malabo")] Malabo,
    [Description("Africa/Brazzaville")] Brazzaville,
    [Description("Africa/Porto-Novo")] PortoNovo,
    [Description("Africa/Douala")] Douala,
    [Description("Africa/Kinshasa")] Kinshasa,
    [Description("Africa/Lagos")] Lagos,
    [Description("Africa/Libreville")] Libreville,
    [Description("Africa/Luanda")] Luanda,
    [Description("Africa/Ndjamena")] Ndjamena,
    [Description("Africa/Niamey")] Niamey,
    [Description("Africa/Bujumbura")] Bujumbura,
    [Description("Africa/Gaborone")] Gaborone,
    [Description("Africa/Harare")] Harare,
    [Description("Africa/Juba")] Juba,
    [Description("Africa/Khartoum")] Khartoum,
    [Description("Africa/Kigali")] Kigali,
    [Description("Africa/Blantyre")] Blantyre,
    [Description("Africa/Lubumbashi")] Lubumbashi,
    [Description("Africa/Lusaka")] Lusaka,
    [Description("Africa/Maputo")] Maputo,
    [Description("Asia/Beirut")] Beirut,
    [Description("Europe/Bucharest")] Bucharest,
    [Description("Africa/Cairo")] Cairo,
    [Description("Europe/Chisinau")] Chisinau,
    [Description("Asia/Hebron")] Hebron,
    [Description("Europe/Helsinki")] Helsinki,
    [Description("Europe/Kaliningrad")] Kaliningrad,
    [Description("Europe/Kyiv")] Kyiv,
    [Description("Europe/Mariehamn")] Mariehamn,
    [Description("Asia/Nicosia")] Nicosia,
    [Description("Europe/Riga")] Riga,
    [Description("Europe/Sofia")] Sofia,
    [Description("Europe/Tallinn")] Tallinn,
    [Description("Africa/Tripoli")] Tripoli,
    [Description("Europe/Vilnius")] Vilnius,
    [Description("Asia/Jerusalem")] Jerusalem,
    [Description("Africa/Johannesburg")] Johannesburg,
    [Description("Africa/Mbabane")] Mbabane,
    [Description("Africa/Maseru")] Maseru,
    [Description("Asia/Kuwait")] Kuwait,
    [Description("Asia/Bahrain")] Bahrain,
    [Description("Asia/Baghdad")] Baghdad,
    [Description("Asia/Qatar")] Qatar,
    [Description("Asia/Riyadh")] Riyadh,
    [Description("Asia/Aden")] Aden,
    [Description("Asia/Amman")] Amman,
    [Description("Asia/Damascus")] Damascus,
    [Description("Africa/Addis_Ababa")] AddisAbaba,
    [Description("Indian/Antananarivo")] Antananarivo,
    [Description("Africa/Asmara")] Asmara,
    [Description("Africa/Dar_es_Salaam")] DarEsSalaam,
    [Description("Africa/Djibouti")] Djibouti,
    [Description("Africa/Kampala")] Kampala,
    [Description("Indian/Mayotte")] Mayotte,
    [Description("Africa/Mogadishu")] Mogadishu,
    [Description("Indian/Comoro")] Comoro,
    [Description("Africa/Nairobi")] Nairobi,
    [Description("Europe/Minsk")] Minsk,
    [Description("Europe/Moscow")] Moscow,
    [Description("Europe/Simferopol")] Simferopol,
    [Description("Antarctica/Syowa")] Syowa,
    [Description("Europe/Istanbul")] Istanbul,
    [Description("Asia/Tehran")] Tehran,
    [Description("Asia/Yerevan")] Yerevan,
    [Description("Asia/Baku")] Baku,
    [Description("Asia/Tbilisi")] Tbilisi,
    [Description("Asia/Dubai")] Dubai,
    [Description("Asia/Muscat")] Muscat,
    [Description("Indian/Mauritius")] Mauritius,
    [Description("Indian/Reunion")] Reunion,
    [Description("Europe/Samara")] Samara,
    [Description("Indian/Mahe")] Mahe,
    [Description("Asia/Kabul")] Kabul,
    [Description("Indian/Kerguelen")] Kerguelen,
    [Description("Indian/Maldives")] Maldives,
    [Description("Antarctica/Mawson")] Mawson,
    [Description("Asia/Karachi")] Karachi,
    [Description("Asia/Dushanbe")] Dushanbe,
    [Description("Asia/Ashgabat")] Ashgabat,
    [Description("Asia/Tashkent")] Tashkent,
    [Description("Asia/Aqtobe")] Aqtobe,
    [Description("Asia/Yekaterinburg")] Yekaterinburg,
    [Description("Asia/Colombo")] Colombo,
    [Description("Asia/Kolkata")] Kolkata,
    [Description("Asia/Kathmandu")] Kathmandu,
    [Description("Asia/Dhaka")] Dhaka,
    [Description("Asia/Thimphu")] Thimphu,
    [Description("Asia/Urumqi")] Urumqi,
    [Description("Asia/Almaty")] Almaty,
    [Description("Indian/Chagos")] Chagos,
    [Description("Asia/Bishkek")] Bishkek,
    [Description("Asia/Omsk")] Omsk,
    [Description("Antarctica/Vostok")] Vostok,
    [Description("Indian/Cocos")] Cocos,
    [Description("Asia/Yangon")] Yangon,
    [Description("Indian/Christmas")] Christmas,
    [Description("Antarctica/Davis")] Davis,
    [Description("Asia/Hovd")] Hovd,
    [Description("Asia/Bangkok")] Bangkok,
    [Description("Asia/Ho_Chi_Minh")] HoChiMinh,
    [Description("Asia/Phnom_Penh")] PhnomPenh,
    [Description("Asia/Vientiane")] Vientiane,
    [Description("Asia/Novosibirsk")] Novosibirsk,
    [Description("Asia/Jakarta")] Jakarta,
    [Description("Australia/Perth")] Perth,
    [Description("Asia/Brunei")] Brunei,
    [Description("Asia/Makassar")] Makassar,
    [Description("Asia/Macau")] Macau,
    [Description("Asia/Shanghai")] Shanghai,
    [Description("Asia/Hong_Kong")] HongKong,
    [Description("Asia/Irkutsk")] Irkutsk,
    [Description("Asia/Kuala_Lumpur")] KualaLumpur,
    [Description("Asia/Manila")] Manila,
    [Description("Asia/Singapore")] Singapore,
    [Description("Asia/Taipei")] Taipei,
    [Description("Asia/Ulaanbaatar")] Ulaanbaatar,
    [Description("Australia/Eucla")] Eucla,
    [Description("Asia/Dili")] Dili,
    [Description("Asia/Jayapura")] Jayapura,
    [Description("Asia/Tokyo")] Tokyo,
    [Description("Asia/Pyongyang")] Pyongyang,
    [Description("Asia/Seoul")] Seoul,
    [Description("Pacific/Palau")] Palau,
    [Description("Asia/Chita")] Chita,
    [Description("Australia/Adelaide")] Adelaide,
    [Description("Australia/Darwin")] Darwin,
    [Description("Australia/Brisbane")] Brisbane,
    [Description("Australia/Sydney")] Sydney,
    [Description("Pacific/Guam")] Guam,
    [Description("Pacific/Saipan")] Saipan,
    [Description("Pacific/Chuuk")] Chuuk,
    [Description("Antarctica/DumontDUrville")] DumontDUrville,
    [Description("Pacific/Port_Moresby")] PortMoresby,
    [Description("Asia/Vladivostok")] Vladivostok,
    [Description("Australia/Lord_Howe")] LordHowe,
    [Description("Pacific/Bougainville")] Bougainville,
    [Description("Antarctica/Casey")] Casey,
    [Description("Pacific/Kosrae")] Kosrae,
    [Description("Pacific/Noumea")] Noumea,
    [Description("Pacific/Norfolk")] Norfolk,
    [Description("Asia/Sakhalin")] Sakhalin,
    [Description("Pacific/Guadalcanal")] Guadalcanal,
    [Description("Pacific/Efate")] Efate,
    [Description("Pacific/Fiji")] Fiji,
    [Description("Pacific/Tarawa")] Tarawa,
    [Description("Pacific/Majuro")] Majuro,
    [Description("Pacific/Nauru")] Nauru,
    [Description("Pacific/Auckland")] Auckland,
    [Description("Antarctica/McMurdo")] McMurdo,
    [Description("Asia/Kamchatka")] Kamchatka,
    [Description("Pacific/Funafuti")] Funafuti,
    [Description("Pacific/Wake")] Wake,
    [Description("Pacific/Wallis")] Wallis,
    [Description("Pacific/Chatham")] Chatham,
    [Description("Pacific/Apia")] Apia,
    [Description("Pacific/Kanton")] Kanton,
    [Description("Pacific/Fakaofo")] Fakaofo,
    [Description("Pacific/Tongatapu")] Tongatapu,
    [Description("Pacific/Kiritimati")] Kiritimati,
}