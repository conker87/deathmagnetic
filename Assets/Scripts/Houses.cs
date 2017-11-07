using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houses : MonoBehaviour {

	public static List<House> GeneratedHouses = new List<House> ();

	void Start() {



	}

	// TODO: Decide if I want to generate new houses every Month, generate some houses and disgard some others, or save them.

	public static void GenerateSomeHouses(int numberToGenerate = 5) {

		if (Zeus.Current == null || Zeus.Current.Player == null) {

			Zeus.Current.CreateNewLife ();

		}

		if (numberToGenerate == -1) {

			// TODO: These need to be in Constants.
			numberToGenerate = Random.Range (4, 12);

		}

		GeneratedHouses.Clear ();

		float average = 1f;

		for (int i = 0; i < numberToGenerate; i++) {

			// TODO: Setting this even before I start on the code as it will more than likely need to be tweaked.
			int bedrooms, bathrooms;
			float baseCost;

			float locationScoreFloat = Random.value;

			// This sets the number of bedrooms depending on the randomly generated locationScore. The score is a raw percentage.
			//	If the location score was 64, then there's a 36% chance for it to have 1 bedroom, (64% * 64%) chance of it being 2, (64% * 64% * 64%) chance of 3, te remaining will be 4.
			//		I think I did the math correct here?
			float bedroomsRand = Random.value;
			bedrooms = (bedroomsRand > locationScoreFloat) ? 1 : 
				((bedroomsRand > locationScoreFloat / 2) ? 2 : 
					((bedroomsRand > locationScoreFloat / 4) ? 3 : 4));
			
			float bathroomsRand = Random.value;
			bathrooms = (bathroomsRand > locationScoreFloat) ? 1 : 
				((bathroomsRand > locationScoreFloat / 3) ? 2 : 
					((bathroomsRand > locationScoreFloat / 6) ? 3 : 4));

			// 10 * a = 30,000;
			// baseCost = 10 * Random.Range(2500, 4500);
			float baseCostRand = Random.value;
			// float baseCostRand = 0f;

			// testing:
			// locationScoreFloat = .05f;

			baseCost = (locationScoreFloat * 100) *
				((baseCostRand > locationScoreFloat) ? Random.Range(2500, 3000) :
					((baseCostRand > locationScoreFloat / 1.25) ? Random.Range(3000, 6500) :
						((baseCostRand > locationScoreFloat / 1.75) ? Random.Range(7500, 10500) : Random.Range(10500, 15000))));

			Debug.Log (string.Format("LS: {7}, {3}B, {4}BA: {0}{1}{2} ({0}{5}{2})/({0}{6}{2}). baseCostRand: {8}",
				Zeus.Current.Player.Nationality.CurrencyStringPrefix,
				string.Format(("{0:n}"), baseCost),
				Zeus.Current.Player.Nationality.CurrencyStringSuffix,
				bedrooms,
				bathrooms,
				baseCost * Zeus.Current.Player.Nationality.CurrencyMultiplier,
				baseCost * Zeus.Current.Player.Nationality.CurrencyMultiplier * Zeus.Current.Player.Nationality.CostOfLivingMultiplier,
				Mathf.RoundToInt(locationScoreFloat * 100),
				baseCostRand));

			GeneratedHouses.Add (new House (bedrooms, bathrooms, Mathf.RoundToInt(locationScoreFloat * 100), baseCost));

			average += baseCost;

		}

		Debug.Log (string.Format("Average: {0}", string.Format(("{0:n}"), average / numberToGenerate)));

	}

}
