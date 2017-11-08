using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyableHousesUIController : MonoBehaviour {

	public RectTransform parent;
	public Button ButtonPrefab;

	public GameObject BuyableHousesDetails_Panel;

	List<House> thisPageEvents = new List<House>();

	int currentPage, supposedMaxPage, maxButtonsPerPage = 6;

	void OnEnable () {

		if (Zeus.Current == null || Zeus.Current.Player == null) {

			return;

		}

		currentPage = 0;
		supposedMaxPage = Mathf.CeilToInt ((float) Houses.List.Count / (float) maxButtonsPerPage) - 1;

		if (Zeus.Current == null) {

			return;

		}

		if (Zeus.Current.Player == null) {

			return;

		}

		DestroyAllButtons ();
		PopulateList ();	
		PopulateButtons ();

	}

	void OnDisable() {

		DestroyAllButtons ();

	}

	void DestroyAllButtons() {

		foreach (Button go in parent.GetComponentsInChildren<Button>()) {

			Destroy (go.gameObject);

		}

	}

	void PopulateList() {

		if (Zeus.Current == null || Zeus.Current.Player == null) {

			return;

		}

		thisPageEvents.Clear ();

		for (int i = (currentPage * maxButtonsPerPage); i < (maxButtonsPerPage * currentPage) + maxButtonsPerPage; i++) {

			if (i > Houses.List.Count - 1) {

				break;

			}

			thisPageEvents.Add (Houses.List [i]);

		}

	}

	void PopulateButtons() {

		if (Zeus.Current == null || Zeus.Current.Player == null) {

			return;

		}

		foreach (House me in thisPageEvents) {

			Button current = Instantiate (ButtonPrefab, parent.transform) as Button;

			current.GetComponentInChildren<Text> ().text = string.Format("{0}{1}{2}",
				Zeus.Current.Player.Nationality.CurrencyStringPrefix,
				string.Format(("{0:n}"), me.CostBase * Zeus.Current.Player.Nationality.CurrencyMultiplier),
				Zeus.Current.Player.Nationality.CurrencyStringSuffix);
			current.onClick.AddListener(delegate { ButtonOnClick (me); });

		}

	}

	public void NextPageination() {

		currentPage++;

		if (currentPage > supposedMaxPage) {

			currentPage = supposedMaxPage;

		}

		DestroyAllButtons ();
		PopulateList ();
		PopulateButtons ();

	}
	public void PreviousPageination() {

		currentPage--;

		if (currentPage < 0) {

			currentPage = 0;

		}

		DestroyAllButtons ();
		PopulateList ();
		PopulateButtons ();	

	}

	void ButtonOnClick(House me) {

		Debug.Log (string.Format ("Would open the BuyableHousesDetails_Panel and show: {0}", me.CostBase));

		if (BuyableHousesDetails_Panel == null) {

			//return;

		}

		// TODO: Show a dialogue box.
		House buttonHouse = new House(me.Bathrooms, me.Bedrooms, me.Garden, me.OffStreetParking, me.LocationScore, me.CostBase, me.CostInterest, me.CostBase * me.CostInterest);

		if (Zeus.Current.Player.Money > (me.CostBase * Zeus.Current.Player.Nationality.CurrencyMultiplier)) {

			// The player is able to pay it off straight away and does not need to get a mortgage

			// TODO: Add a dialogue asking if the player would like to actually pay it off.
			Zeus.Current.Player.Money -= (me.CostBase * Zeus.Current.Player.Nationality.CurrencyMultiplier);


		}

		Zeus.Current.Player.OwnedHouses.Add (buttonHouse);

		Houses.List.Remove (me);
		supposedMaxPage = Mathf.CeilToInt ((float) Houses.List.Count / (float) maxButtonsPerPage) - 1;

		DestroyAllButtons ();
		PopulateList ();	
		PopulateButtons ();

	}
}
