using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class House {

	public int Bathrooms, Bedrooms, LocationScore;
	public bool Garden, OffStreetParking;
	public float CostBase, CostBasedOnCurrency, CostBasedOnLivingCost;

	public float CostLeft, CostInterest, CostTotal;

	public House(int bathrooms, int bedrooms, bool garden, bool offStreetParking, int locationScore, float costBase, float costInterest, float costLeft) {

		Bathrooms = bathrooms;
		Bedrooms = bedrooms;
		Garden = garden;
		OffStreetParking = offStreetParking;
		CostBase = costBase;
		LocationScore = locationScore;
		CostBasedOnCurrency = CostBase * Zeus.Current.Player.Nationality.CurrencyMultiplier;
		CostBasedOnLivingCost = CostBasedOnCurrency * Zeus.Current.Player.Nationality.CostOfLivingMultiplier;
		CostInterest = costInterest;
		costLeft = CostLeft;

		CostTotal = CostBase * CostInterest;

		CostTotal = -1f;

	}

}
