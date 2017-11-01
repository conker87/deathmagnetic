using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nationality {

	// ISO Alpha-3, English Country Name, Nationality
	public static Dictionary<string, NationalityDetails> Nationalities = new Dictionary<string, NationalityDetails> {

		// TODO: Finish this list and check what nationality people are.

		{ "ENG", new NationalityDetails("England", "English") },
		{ "AFG", new NationalityDetails("Afghanistan", "Afghanistanian?") },
		{ "ALA", new NationalityDetails("Aland Islands", "English") },
		{ "ALB", new NationalityDetails("Albania", "Albanian") },
		{ "DZA", new NationalityDetails("Algeria", "Algerian") },
		{ "ASM", new NationalityDetails("American Samoa", "Samoan") }

	};

}

public class NationalityDetails {

	public NationalityDetails(string countryName, string nationality) {

		CountryName = countryName;
		Nationality = nationality;

	}

	public string CountryName, Nationality;

}
