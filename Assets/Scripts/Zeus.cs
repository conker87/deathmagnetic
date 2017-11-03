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

	public float fx = 1.0375f;

	// This is for all the choices the user can pick, all choices need to be added to this array and removed once the
	//	user has picked.
	// DialogueBox[] queuedDialogueBoxes;

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
		Mother.FirstName = "Mother";

		Father = gameObject.AddComponent<Parent> ();
		Father.ParentType = ParentType.FATHER;
		Father.Create ();
		Father.FirstName = "Father";

		// TODO: Try and remember the word instead of lifetime.
		Mother.CurrentVaccines.Add (new Vaccination ("Lifetime? Immunity", "All Vaccines", -1, 5000));
		Father.CurrentVaccines = Mother.CurrentVaccines;

		// For testing purposes.
		Mother.Intellect = Father.Intellect = 100f;

		Player = gameObject.AddComponent<Player> ();
		Player.Create ();
		Player.FirstName = "Player";

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

	public void _DEBUG_GiveVaccination(Vaccination[] vaccinations) {

		Player.CurrentVaccines.AddRange (vaccinations);

	}

	public void _DEBUG_testVaccines() {

		Player.ProcessVaccines();

	}

	public static float CalculateBaseChanceToDie(int age) {

		float coeffient = 1f;

		if (age == Constants.LIFE_ABSOLUTE_MAX_AGE_IN_MONTHS * 12) {

			coeffient = 0.001f;

		}

		// TODO: These need tweaking as a 1% chance to die every 75% is pretty bad.
		if (age < 124*12) {

			coeffient = 1.0000759375f;
		}
		if (age < 100*12) {

			coeffient = 1.000050625f;
		}
		if (age < 80*12) {

			coeffient = 1.00003375f;
		}
		if (age < 60*12) {

			coeffient = 1.0000225f;
		}
		if (age < 40*12) {

			coeffient = 1.000015f;
		}
		if (age < 20*12) {

			coeffient = 1.00001f;
		}

		return Mathf.Pow (coeffient, age);

	}

	public static Nationality SetNationality() {

		return Nationalities.List[Random.Range(0, Nationalities.List.Count)];;

	}

	public void _DEBUG_DoFx() {

		for (int i = 0; i <= 125; i++) {

			Debug.Log (string.Format ("{0} yo: {1}", i, Mathf.Pow(fx, i)));

		}

	}

		
	// Update is called once per frame
	void Update () {
		
	}
}
