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

		Mother = gameObject.AddComponent<Parent> ();
		Mother.ParentType = ParentType.MOTHER;
		Mother.Create ();

		Father = gameObject.AddComponent<Parent> ();
		Father.ParentType = ParentType.FATHER;
		Father.Create ();

		// TODO: Try and remember the word instead of lifetime.
		Mother.Vaccines.Add (new Vaccination ("Lifetime? Immunity", "All Vaccines", -1, 5000));
		Father.Vaccines = Mother.Vaccines;

		// For testing purposes.
		Mother.Intellect = Father.Intellect = 100f;

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

	public void GiveVaccination(Vaccination[] vaccinations) {

		Player.Vaccines.AddRange (vaccinations);

	}

	public void testVaccines() {

		Player.ProcessVaccines();

	}

	public static Nationality SetNationality() {

		return Nationalities.List[Random.Range(0, Nationalities.List.Count)];;

	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
