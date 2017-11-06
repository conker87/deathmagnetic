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

	public List<MajorEvent> MajorEvents = new List<MajorEvent>();

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

		Age = -1;

		#region Nationalitiy
		Nationality = (Random.value > 0.5f) ? Mother.Nationality : Father.Nationality;
		#endregion

		// Check 
		// ProcessDiseases (true);

		Zeus.ResetOutput ();

		Zeus.QueueToOutput ("————————————————————");

		Zeus.QueueToOutput (string.Format("You are <b>{0} {1}</b>.", FirstName, LastName));
		Zeus.QueueToOutput (string.Format("You are born <b>{0}</b>.", Zeus.ToTitleCase(Gender.ToString().ToLower())));
		Zeus.QueueToOutput (string.Format("You were born in <b>{0}</b>, your nationality is <b>{1}</b>.", Nationality.CountryName, Nationality.Demonym));

		Zeus.QueueToOutput (string.Format("Your Mother is: <b>{0} {1}</b>, " + ((Mother.Gender == Gender.FEMALE) ? "her" : "his") + " nationality is <b>{2}</b>.", Mother.FirstName, Mother.LastName, Mother.Nationality.Demonym));
		Zeus.QueueToOutput (string.Format("Your Father is: <b>{0} {1}</b>, " + ((Father.Gender == Gender.FEMALE) ? "her" : "his") + " nationality is <b>{2}</b>.", Father.FirstName, Father.LastName, Father.Nationality.Demonym));
		if (IsAdopted) Zeus.QueueToOutput (string.Format("<b>You are adopted.</b>"));
	
		Zeus.QueueToOutput ("————————————————————");
		Zeus.QueueToOutput ();

		MajorEvents.Add (new MajorEvent ("Born", 0,
			string.Format("You were born. You are a <b>{0}</b>. Your nationality is <b>{1}</b>. Your Mother is <b>{2}</b> and your Father is <b>{3}</b>.",
				FirstName + " " + LastName,
				Nationality.Demonym,
				Mother.FirstName + " " + Mother.LastName,
				Father.FirstName + " " + Father.LastName),
				Zeus.Current.Player.IncrementLastIndexMajorEvent())
		);

		ProcessAging ();

	}

	public override void ProcessAging () {

		base.ProcessAging ();

		if (IsDead) {

			Zeus.QueueToOutput ("You have died.");

			MajorEvents.Add (new MajorEvent ("Died", Age,
				string.Format("You Died."),
				Zeus.Current.Player.IncrementLastIndexMajorEvent())
			);

			// TODO: Disable elements.

			return;

		}

		ProcessVaccines ();

		ProcessGuitarLearning ();

		if (Age == 12 * 5) {

			AtSchool = true;
			Zeus.QueueToOutput ("You started school.");
			Zeus.QueueToOutput ();

			MajorEvents.Add (new MajorEvent ("School", Age,
				string.Format("You started school."),
				Zeus.Current.Player.IncrementLastIndexMajorEvent())
			);

		}

		if (Age == 12 * 16) {

			AtSchool = false;

		}

		if (AtSchool) {

			Intellect += Constants.SCHOOL_BACKGROUND_INTELLECT_GAIN_PER_MONTH;
			intellectModifier.ForEach (x => Intellect += x);

		}
			
		Zeus.QueueToOutput (OutputAge ());
		Zeus.QueueToOutput ();

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
			bool wasVaccination = false;
			string _vaccine = "";
			List<string> _vaccines = new List<string>();

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

					if (!hasMissed) {

						wasVaccination = true;
						_vaccine = currentVaccineToAdd.Vaccine;
						_vaccines.Add(string.Format(currentVaccineToAdd.Disease + ((vld.MaxProtectionTime == 5000) ? " forever" : " for {0} months"), vld.MaxProtectionTime));

					}

				}

			}


			if (wasVaccination) {

				string _vaccinesTemp = "";

				_vaccines.ForEach (x => _vaccinesTemp += "• " + x + ".\n");
				_vaccinesTemp = _vaccinesTemp.Remove (_vaccinesTemp.Length - 1);

				Zeus.QueueToOutput (string.Format("You had the {0} vaccination, you are now protected from the following diseases:\n{1}", _vaccine, _vaccinesTemp));
				Zeus.QueueToOutput ();

				_vaccinesTemp = "";

				_vaccines.ForEach (x => _vaccinesTemp += x + ", ");
				_vaccinesTemp = _vaccinesTemp.Remove (_vaccinesTemp.Length - 2);
				MajorEvents.Add (new MajorEvent ("Vaccinated", Age,
					string.Format("You were vaccinationed. You got the {0} vaccine, which protects you against {1}.",
						_vaccine,
						_vaccinesTemp),
					Zeus.Current.Player.IncrementLastIndexMajorEvent())
				);

			}

			i++;

		}

	}

	// TODO: Add Process functions for all skills.
	void ProcessGuitarLearning() {

		if (LearningGuitar && startedGuitar.Count > 0) {

			// TODO: Tweak these numbers, you should not have very high modifiers per month
			float chanceToAddModifier = (1 / (Age - startedGuitar [startedGuitar.Count - 1] + 0.01f)) * Constants.BASE_SKILL_CHANCE_TO_ADD_MODIFIER_MOD;

			// Debug.Log (string.Format("chanceToIncreaseModifier: {0}", chanceToAddModifier));

			if (Random.value < chanceToAddModifier) {

				float ageModifier = Age - startedGuitar [startedGuitar.Count - 1];
				float ageModified = ageModifier * Constants.BASE_SKILL_AGE_MODIFIER_MOD;

				// Debug.Log (string.Format("ageModifier: {0}", ageModified));

				guitarModifier.Add (Random.Range (0.1f, ageModified));

			}

			guitarModifier.ForEach (x => Guitar += x);
			if (guitarModifier.Count == 0) {
				Guitar += Constants.BASE_SKILL_INCREASE_PER_MONTH;
			}

			guitarModifier.ForEach (x => Guitar += x);

		}

		Guitar = Mathf.Clamp (Guitar, 0f, 1000f);
  	}

	string OutputAge() {

		int months = Age % 12;
		int ageInYearsOutput = (Age / 12);

		return string.Format ("<u>You are {0} year(s) and {1} month(s) old.</u>", ageInYearsOutput, months);

	}

	public int IncrementLastIndexMajorEvent() {

		return (MajorEvents != null && MajorEvents.Count > 0) ? MajorEvents.Count : 0;

	}

}
