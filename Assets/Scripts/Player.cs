using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Life {

	// Player only vitals
	[SerializeField]
	Parent mother, father;

	public Parent Mother			{	get { return mother; 			}	set { mother = value; 			} 	}
	public Parent Father			{	get { return father; 			}	set { father = value; 			} 	}

	[SerializeField]
	bool isAdopted = false;

	public bool IsAdopted			{	get { return isAdopted; 		}	set { isAdopted = value; 		} 	}

	// Schooling
	[SerializeField]
	bool atSchool, atUniversity;

	public bool AtSchool			{	get { return atSchool; 			}	set { atSchool = value; 		} 	}
	public bool AtUniversity		{	get { return atUniversity; 		}	set { atUniversity = value; 	} 	}

	// Current Acitivies
	[SerializeField]
	public List<float> intellectModifier = new List<float> (), guitarModifier = new List<float> ();

	// Learnable skills
	[Range(0, 1000)][SerializeField]
	float guitar, piano, violin, art, talking, building;
	[SerializeField]
	bool isStudying, learningGuitar, learningPiano, learningViolin, learningArt, learningTalking, learningBuilding;
	[SerializeField]
	public List<int> startedGuitar = new List<int> (); // Do for all.
	// Add more?

	public bool IsStudying	 		{	get { return isStudying; 		}	set { isStudying = value; 	}	}
	public bool LearningGuitar 		{	get { return learningGuitar; 	}	set { learningGuitar = value; 	}	}
	public bool LearningPiano 		{	get { return learningPiano; 	}	set { learningPiano = value; 	}	}
	public bool LearningViolin 		{	get { return learningViolin; 	}	set { learningViolin = value; 	}	}
	public bool LearningArt 		{	get { return learningArt; 		}	set { learningArt = value; 		}	}
	public bool LearningTalking 	{	get { return learningTalking; 	}	set { learningTalking = value; 	}	}
	public bool LearningBuilding 	{	get { return learningBuilding; 	}	set { learningBuilding = value; }	}

	public float Guitar 	{	get { return guitar; 	}	set { guitar = value; 	}	}
	public float Piano 		{	get { return piano; 	}	set { piano = value; 	}	}
	public float Violin 	{	get { return violin; 	}	set { violin = value; 	}	}
	public float Art 		{	get { return art; 		}	set { art = value; 		}	}
	public float Talking 	{	get { return talking; 	}	set { talking = value; 	}	}
	public float Building 	{	get { return building; 	}	set { building = value; }	}

	// Your current spouse, if any;
	Spouse spouse;

	public Spouse Spouse	{	get { return spouse; 	}	set { spouse = value; }	}

	public void Create() {

		Mother = Zeus.Current.Mother;
		Father = Zeus.Current.Father;

		#region Sexuality
		Sexuality = Sexuality.NULL;
		Gender = (Random.value > 0.5f) ? Gender.MALE : Gender.FEMALE;
		#endregion

		IsAdopted = (Zeus.Current.Mother.Gender == Zeus.Current.Father.Gender);

		#region Basic Stats
		Happiness = 100f;
		Appearance = 50f;
		Fitness = 5f;
		Intellect = 5f;
		#endregion

		#region Nationalitiy
		Nationality = (Random.value > 0.5f) ? Mother.Nationality : Father.Nationality;
		#endregion

		// Check 
		ProcessDiseases (true);

	}

	public override void ProcessAging () {

		base.ProcessAging ();

		if (IsDead) {

			return;

		}

		ProcessVaccines ();

		ProcessGuitarLearning ();

		if (Age == 12 * 5) {

			AtSchool = true;

		}

		if (Age == 12 * 16) {

			AtSchool = false;

		}

		if (AtSchool) {

			Intellect += Constants.SCHOOL_BACKGROUND_INTELLECT_GAIN_PER_MONTH;
			intellectModifier.ForEach (x => Intellect += x);

		}


	}

	public void ProcessVaccines() {

		// Check to see if a Vaccination has expired, if so, remove it from the Vaccine list.
		foreach (Vaccination vd in CurrentVaccines) {

			if (vd.Missed || vd.Expired) {

				continue;

			}

			if (Age == (vd.AgeImmunised + vd.MaxProtectionTime)) {

				vd.Expired = true;
				// Debug.Log (string.Format ("Found vaccinaton: {0}, of which diseases: {1} has expired as it only lasts for {2} months",
				//	vd.Vaccine, vd.Disease, vd.MaxProtectionTime));

			}

		}

		// Check for new vaccines needed.
		// Iterate through all known vaccine routines
		foreach (Vaccination[] vaccine in Vaccinations.List) {

			int i = 0;
			bool routineMissed = false;

			// Iterate through all diseases in these routines
			foreach (Vaccination vld in vaccine) {

				// If our current Age is more or equal to the age at which you get the vaccine, then you will have a chance
				//	to get the vaccine.
				if (Age == vld.AgeImmunised) {

					// TODO: This definitely needs tuning, there are some issues.
					float intellectVaxModifier = Mathf.Clamp (1 / ((Mother.Intellect + Father.Intellect)), 0f, 1f);
					bool hasMissed = !(Random.value >= intellectVaxModifier);

					if (i == 0 && hasMissed) {
						routineMissed = true;
					}

					Vaccination currentVaccineToAdd = new Vaccination(vld);

					currentVaccineToAdd.Missed = currentVaccineToAdd.Expired = routineMissed;

					CurrentVaccines.Add (currentVaccineToAdd);

				}

			}

			i++;

		}

	}

	// TODO: Add Process functions for all skills.
	void ProcessGuitarLearning() {

		if (LearningGuitar) {

			// Tweak these numbers, you should not have very high modifiers per month
			//	
			float chanceToAddModifier = (1 / (Age - startedGuitar [startedGuitar.Count - 1] + 0.01f)) * Constants.BASE_SKILL_CHANCE_TO_ADD_MODIFIER_MOD;

			Debug.Log (string.Format("chanceToIncreaseModifier: {0}", chanceToAddModifier));

			if (Random.value < chanceToAddModifier) {

				float ageModifier = Age - startedGuitar[startedGuitar.Count - 1];
				float ageModified = ageModifier * Constants.BASE_SKILL_AGE_MODIFIER_MOD;

				// Debug.Log (string.Format("ageModifier: {0}", ageModified));

				guitarModifier.Add(Random.Range(0.1f, ageModified));

			}

			guitarModifier.ForEach (x => Guitar += x);
			if (guitarModifier.Count == 0) {
				Guitar += Constants.BASE_SKILL_INCREASE_PER_MONTH;
			}

			guitarModifier.ForEach (x => Guitar += x);
		}

		Guitar = Mathf.Clamp (Guitar, 0f, 1000f);

  	}

}
