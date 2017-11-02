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
	bool learningGuitar, learningPiano, learningViolin, learningArt, learningTalking, learningBuilding;
	[SerializeField]
	public List<int> startedGuitar = new List<int> (); // Do for all.
	// Add more?

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
		Happiness = 100;
		Appearance = 50;
		Fitness = 5;
		Intellect = 5;
		#endregion

		#region Nationalitiy
		Nationality = (Random.value > 0.5f) ? Mother.Nationality : Father.Nationality;
		#endregion

	}

	public override void ProcessAging () {

		if (AtSchool) {

			Intellect += Constants.SCHOOL_BACKGROUND_INTELLECT_GAIN_PER_MONTH;
			intellectModifier.ForEach (x => Intellect += x);

		}

		if (LearningGuitar) {

			// Tweak these numbers, you should not have very high modifiers per month
			//	
			float chanceToIncreaseModifier = (1 - (1 / (Age - startedGuitar [startedGuitar.Count - 1] + 0.01f))) * 0.1f;

			Debug.Log (string.Format("chanceToIncreaseModifier: {0}", chanceToIncreaseModifier));

			if (Random.value < chanceToIncreaseModifier) {

				float ageModifier = Age - startedGuitar[startedGuitar.Count - 1];
				float ageModified = ageModifier * 0.003f;

				Debug.Log (string.Format("ageModifier * 0.5f: {0}", ageModified));

				guitarModifier.Add(Random.Range(0.1f, ageModified));

			}

			guitarModifier.ForEach (x => Guitar += x);
			if (guitarModifier.Count == 0) {
				Guitar += Constants.BASE_SKILL_INCREASE_PER_MONTH;
			}


		}

		guitarModifier.ForEach (x => Guitar += x);

		// This needs to go at the end of the aging processes, with the above stuff happening.
		base.ProcessAging ();

	}

	void Start() {

		/* Testing for natural death causes percentage, the value we want is:
		 * value = Mathf.Pow (1.0375f, i) - 0.95f;
		 * 
		 * Where i is the AgeInYears (Age / 12).
		 * 
		 * 
		for (int i = 0; i < 126; i++) {

			float value;

			// Value taken from Juicybutts_, off that there twitch.
			value = Mathf.Pow (1.0375f, i) - 0.95f;

			Debug.Log (string.Format("{1}: {0}", value, i));

		} */


	}

}
