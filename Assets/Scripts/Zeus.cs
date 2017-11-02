using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeus : MonoBehaviour {

	#region Singleton
	public static Zeus Current = null;

	void Awake() {

		if (Current == null) {
			Current = this;
		} else if (Current != this) {
			Destroy (gameObject);    
		}

		DontDestroyOnLoad(gameObject);

	}
	#endregion

	public Player Player;
	public Parent Mother, Father;

	public void CreateNewLife() {

		if (Mother != null) {

			Destroy (Mother);
			Mother = null;

		}

		if (Father != null) {

			Destroy (Father);
			Father = null;

		}

		if (Player != null) {

			Destroy (Player);
			Player = null;

		}

		Mother = gameObject.AddComponent<Parent> ();
		Mother.ParentType = ParentType.MOTHER;
		Mother.Create ();

		Father = gameObject.AddComponent<Parent> ();
		Father.ParentType = ParentType.FATHER;
		Father.Create ();

		Player = gameObject.AddComponent<Player> ();
		Player.AmAdopted = (Mother.Gender == Father.Gender);
		Player.Create ();

	}

	NationalityDetails SetNationality() {

		// Picking a random dictionary keypair by putting the Keys into a list, getting a random value from there
		//		and putting the return value into the original dictionary.

		List<string> keyList = new List<string> (Nationality.Nationalities.Keys);

		string code = keyList[Random.Range(0, keyList.Count)];
		NationalityDetails random = Nationality.Nationalities [code];

		if (random != null) {

			Debug.Log (string.Format ("Nationality picked as: {0}, you're from {1}, the code is: {2}. Your currency is {3}, and the format is: {4}4,000{5}",
				random.Nationality, random.CountryName,
				random.CountryCode, random.CurrencyName,
				random.CurrencyStringPrefix, random.CurrencyStringSuffix));

		}

		return random;

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
