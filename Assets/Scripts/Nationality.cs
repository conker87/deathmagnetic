using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nationality {

	// ISO Alpha-3, English Country Name, Nationality
	public static Dictionary<string, NationalityDetails> Nationalities = new Dictionary<string, NationalityDetails> {

		// TODO: Finish this list, check what nationality people are, find and complete currency names & symbols, exchange rates and general cost of living.

		{ "ENG", new NationalityDetails("ENG", "England", "English", "British Pound", "£", "", 1f) },
		{ "AFG", new NationalityDetails("AFG", "Afghanistan", "Afghan", "Afghan Afghani", "", char.ConvertFromUtf32(0x060B).ToString(), 90.75f) },   // ؋
		{ "ALB", new NationalityDetails("ALB", "Albania", "Albanian", "Albanian Lek", "Lek", "", 152.65f) },
		{ "DZA", new NationalityDetails("DZA", "Algeria", "Algerian", "Algerian Dinar", "", "", 153.68f) },
		{ "ASM", new NationalityDetails("ASM", "American Samoa", "Samoan", "US Dollar", "$", "", 1.33f) },
		{ "INR", new NationalityDetails("INR", "India", "Indian", "Indian Rupee", "₹", "", 85.82f) }

	};

}

[System.Serializable]
public class NationalityDetails {

	public NationalityDetails(string countryCode, string countryName, string nationality, string currencyName, string currencyStringPrefix, string currencyStringSuffix, float currencyMultiplier) {

		CountryName = countryName;
		Nationality = nationality;
		CurrencyName = currencyName;
		CurrencyStringPrefix = currencyStringPrefix;
		CurrencyStringSuffix = currencyStringSuffix;
		CurrencyMultiplier = currencyMultiplier;
		CostOfLivingMultiplier = 1f;

	}

	public NationalityDetails(string countryCode, string countryName, string nationality, string currencyName,  string currencyStringPrefix, string currencyStringSuffix,  float currencyMultiplier, float costOfLivingMultiplier) {

		CountryCode = countryCode;
		CountryName = countryName;
		Nationality = nationality;
		CurrencyName = currencyName;
		CurrencyStringPrefix = currencyStringPrefix;
		CurrencyStringSuffix = currencyStringSuffix;
		CurrencyMultiplier = currencyMultiplier;
		CostOfLivingMultiplier = costOfLivingMultiplier;

	}

	public string CountryCode, CountryName, Nationality, CurrencyName, CurrencyStringPrefix, CurrencyStringSuffix;
	public float CurrencyMultiplier, CostOfLivingMultiplier;

}
