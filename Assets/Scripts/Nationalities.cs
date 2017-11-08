using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nationalities {

	// ISO Alpha-3, English Country Name, Nationality
	public static List<Nationality> List = new List<Nationality> {

		// TODO: Finish this list, check what nationality people are, find and complete currency names & symbols, exchange rates and general cost of living.

		{ new Nationality("ENG", "England",			"English", 		"British Pound", "£", "", 1f) },
		{ new Nationality("AFG", "Afghanistan",		"Afghan", 		"Afghan Afghani", "", char.ConvertFromUtf32(0x060B).ToString(), 90.75f) },   // ؋
		{ new Nationality("ALB", "Albania",			"Albanian", 	"Albanian Lek", "Lek", "", 152.65f) },
		{ new Nationality("DZA", "Algeria",			"Algerian", 	"Algerian Dinar", "", "", 153.68f) },
		{ new Nationality("ASM", "American Samoa",	"Samoan", 		"US Dollar", "$", "", 1.33f) },
		{ new Nationality("INR", "India",			"Indian", 		"Indian Rupee", "₹", "", 85.82f) },
		{ new Nationality("JPN", "Japan",			"Japanese", 	"Japanese Yen", "¥", "", 149.888f) }

	};

}

[System.Serializable]
public class Nationality {

	public string CountryCode, CountryName, Demonym, CurrencyName, CurrencyStringPrefix, CurrencyStringSuffix;
	public float CurrencyMultiplier, CostOfLivingMultiplier;

	public Nationality(string countryCode, string countryName, string demonym, string currencyName,  string currencyStringPrefix, string currencyStringSuffix,  float currencyMultiplier, float costOfLivingMultiplier = 1f) {

		CountryCode = countryCode;
		CountryName = countryName;
		Demonym = demonym;
		CurrencyName = currencyName;
		CurrencyStringPrefix = currencyStringPrefix;
		CurrencyStringSuffix = currencyStringSuffix;
		CurrencyMultiplier = currencyMultiplier;
		CostOfLivingMultiplier = costOfLivingMultiplier;

	}

}
