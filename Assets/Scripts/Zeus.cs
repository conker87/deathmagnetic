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
	public Spouse Spouse;
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
		Player.Create ();

	}

	public void AgeMonth(int monthsToAge) {

		if (Player == null || Mother == null || Father == null) {

			return;

		}

		int i = 0;

		while (monthsToAge > i) {

			Player.ProcessAging ();
			if (Spouse != null) Spouse.ProcessAging ();
			Mother.ProcessAging ();
			Father.ProcessAging ();

			i++;
		}

	}

	public void LearningGuitarToggle() {

		if (!Player.LearningGuitar) {

			Player.LearningGuitar = true;
			Player.startedGuitar.Add (Player.Age);

		} else {

			Player.LearningGuitar = false;

		}

	}

	public static NationalityDetails SetNationality() {

		// Picking a random dictionary keypair by putting the Keys into a list, getting a random value from there
		//		and putting the return value into the original dictionary.
		List<string> keyList = new List<string> (Nationality.Nationalities.Keys);

		string code = keyList[Random.Range(0, keyList.Count)];
		NationalityDetails random = Nationality.Nationalities [code];

		return random;

	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
