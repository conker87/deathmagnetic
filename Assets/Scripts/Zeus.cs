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

		Destroy (Spouse);

		Mother = gameObject.AddComponent<Parent> ();
		Mother.ParentType = ParentType.MOTHER;
		Mother.FirstName = "Mother";
		Mother.Create ();

		Father = gameObject.AddComponent<Parent> ();
		Father.ParentType = ParentType.FATHER;
		Father.FirstName = "Father";
		Father.Create ();

		// TODO: Try and remember the word instead of lifetime.
		Mother.CurrentVaccines.Add (new Vaccination ("Lifetime? Immunity", "All Vaccines", -1, 5000));
		Father.CurrentVaccines = Mother.CurrentVaccines;

		// For testing purposes.
		Mother.Intellect = Father.Intellect = 100f;

		Player = gameObject.AddComponent<Player> ();
		Player.FirstName = "Player";
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

	public void _DEBUG_GiveVaccination(Vaccination[] vaccinations) {

		Player.CurrentVaccines.AddRange (vaccinations);

	}

	public void _DEBUG_testVaccines() {

		Player.ProcessVaccines();

	}

	public static float CalculateBaseChanceToRandomlyDie(int age) {

		float coeffient = 1.00001f;

		// TODO: These possibly still need tweaking, play-testing is needed.
		if (age >= 0) {

			coeffient = 1.00001f;
		}
		if (age >= (20*12)) {

			coeffient = 1.000011f;
		}
		if (age >= (40*12)) {

			coeffient = 1.000012f;
		}
		if (age >= (60*12)) {

			coeffient = 1.00002f;
		}
		if (age >= (80*12)) {

			coeffient = 1.00025f;
		}
		if (age >= (100*12)) {

			coeffient = 1.0005f;
		}
		if (age >= Constants.LIFE_ABSOLUTE_MAX_AGE_IN_MONTHS) {

			coeffient = 2f;

		}

		return (Mathf.Pow (coeffient, age) - 1f) / 100f;

	}

	public static Nationality SetNationality() {

		return Nationalities.List[Random.Range(0, Nationalities.List.Count)];;

	}

		
	// Update is called once per frame
	void Update () {
		
	}
}
