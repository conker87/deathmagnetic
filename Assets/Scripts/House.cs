using System.Collections;
using System.Collections.Generic;

public class House {

	public int Bathrooms, Bedrooms, LocationScore;
	public float CostBase, CostBasedOnCurrency, CostBasedOnLivingCost;

	public House(int bathrooms, int bedrooms, int locationScore, float costBase) {

		Bathrooms = bathrooms;
		Bedrooms = bedrooms;
		CostBase = costBase;
		LocationScore = locationScore;
		CostBasedOnCurrency = CostBase * Zeus.Current.Player.Nationality.CurrencyMultiplier;
		CostBasedOnLivingCost = CostBasedOnCurrency * Zeus.Current.Player.Nationality.CostOfLivingMultiplier;

	}

}
