using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	// Vitals
	[SerializeField]
	string firstname, lastname;
	[SerializeField]
	int age, ageInYears;
	[SerializeField]
	Gender gender;
	[SerializeField]
	Sexuality sexuality;
	[SerializeField]
	Nationality nationality;
	[SerializeField]
	bool isDead;

	public string FirstName			{	get { return firstname; 		}	set { firstname = value; 		} 	}
	public string LastName			{	get { return lastname; 			}	set { lastname = value; 			} 	}
	public Gender Gender			{	get { return gender; 			}	set { gender = value; 			}	}
	public Sexuality Sexuality		{	get { return sexuality;			}	set { sexuality = value; 		} 	}
	public int Age					{	get { return age;				}	set { age = value; 				} 	} // THIS IS IN MONTHS!
	public int AgeInYears			{	get { return ageInYears;		}	set { ageInYears = value; 		} 	}
	public bool IsDead				{	get { return isDead;			}	set { isDead = value; 		} 	}

	int previousAge;

	[SerializeField]
	public List<float> deathChanceModifier = new List<float> ();

	public Nationality Nationality	{	get { return nationality; }	set { nationality = value;	} 	}

	[SerializeField]
	List<Disease> diseases = new List<Disease>();
	public List<Disease> CurrentDiseases 			{	get { return diseases; 	}	set { diseases = value; 	}	}
	[SerializeField]
	List<Vaccination> vaccines = new List<Vaccination>();
	public List<Vaccination> CurrentVaccines 		{	get { return vaccines; 	}	set { vaccines = value; 	}	}

	// Basic Stats
	[Range(0, 100)][SerializeField]
	float happiness, appearance, fitness, intellect;

	public float Happiness	{	get { return happiness;		}	set { happiness = value; 	} 	}
	public float Appearance	{	get { return appearance;	}	set { appearance = value; 	}	}
	public float Fitness 	{	get { return fitness;		}	set { fitness = value; 		}	}
	public float Intellect 	{	get { return intellect;		}	set { intellect = value; 	}	}

	protected virtual void Update() {

		AgeInYears = Age / 12;
		Happiness	= Mathf.Clamp (Happiness, 0f, 100f);
		Appearance	= Mathf.Clamp (Appearance, 0f, 100f);
		Fitness		= Mathf.Clamp (Fitness, 0f, 100f);
		Intellect	= Mathf.Clamp (Intellect, 0f, 100f);

	}

	protected virtual void Die() {

		IsDead = true;

		// Life has died, if it's a parent or spouse then show a dialogue box and set the appropriate details in game,
		//	If it's the player, disable all Aging buttons and give them a summery of their life while allowing them to see
		//	what they accomlished in other tabs.

	}

	public virtual void ProcessAging() {

		// 75% chance per month to check to die.
		if (Random.value <= Constants.LIFE_CHANCE_TO_CHECK_IF_MONTH_COULD_KILL_YOU / 100f) {

			float chanceToDie = Zeus.CalculateBaseChanceToRandomlyDie(Age);
			float ran = Random.value;

			deathChanceModifier.ForEach (x => chanceToDie += ((x / 100f) / 100f));

			if (ran < chanceToDie) {

				Die ();

			}

			if (this.FirstName == "Player") {
				// Debug.Log (string.Format ("{0} (At Age: {3}/{4}: {1}% ({2}). Killed you? {5}", this.FirstName, (chanceToDie * 100f).ToString("N7"), ran, Age, Age / 12, (ran < chanceToDie)));
			}

		}

		if (Age == Constants.LIFE_ABSOLUTE_MAX_AGE_IN_MONTHS) {

			Die ();

		}

		if (!IsDead) {

			Age++;

		}
			
		ProcessDiseases ();

	}

	protected void ProcessDiseases(bool justBeenBorn = false) {

		// TODO: We need to add anything that happens from here into the main Label.
		// Check for diseases and add them if it is randomly chosen.
		foreach (Disease d in Diseases.List) {

			if (CheckIfLifeHasDisease(d.DiseaseName)) {

				// Debug.Log (string.Format ("{0} already has {1} and so cannot get it again.", this, d.DiseaseName));
				continue;

			}

			if ((justBeenBorn && d.DiseaseType == DiseaseType.BORN) || d.DiseaseType == DiseaseType.CONTRACT) {

				float contractionChance = d.ChanceToContract / 100f, reducedChanceToContract = 1f;

				if (CheckIfLifeHasVaccination(d.DiseaseName, out reducedChanceToContract)) {

					contractionChance /= reducedChanceToContract;

				}

				float chanceToContractRand = Random.value;

				// Debug.Log (string.Format("chanceToContractRand: {0}, contractionChance: {1}", chanceToContractRand, contractionChance / 100f));

				if (chanceToContractRand < (contractionChance)) {

					Disease currentDiseaseToAdd = new Disease (d);

					currentDiseaseToAdd.AgeContracted = this.Age;

					CurrentDiseases.Add (currentDiseaseToAdd);
					deathChanceModifier.Add (d.IncreasedChanceToDie);

					if (this is Player) {
					
						string output = string.Format ("You have contracted {0}!", d.DiseaseName);

						Zeus.QueueToOutput (output);
						// Debug.Log (output);

					}

				}

			}

		}

		List<Disease> currentDiseasesToRemove = new List<Disease> ();
		currentDiseasesToRemove.Clear ();

		// Check for current diseases and remove if applicable.
		foreach (Disease d in CurrentDiseases) {

			if (!d.CanBeCured) {

				continue;

			}

			int averageLengthOfDisease = d.AverageLength;
			int ageOfDisease = this.Age - d.AgeContracted;
			float coefficent = 1.5f;

			// TODO: More play-testing is needed to determine if this is the correct formula.
			float chanceToBeCuredThisMonth = ((float) ageOfDisease / (float) averageLengthOfDisease) / coefficent;
			chanceToBeCuredThisMonth *= Random.Range (1f - (1f / averageLengthOfDisease), 1.01f);

			float chanceToRemoveDiseaseRan = Random.value;

			if (chanceToRemoveDiseaseRan < chanceToBeCuredThisMonth) {

				currentDiseasesToRemove.Add (d);
				deathChanceModifier.Remove (d.IncreasedChanceToDie);

				if (this is Player) {

					string output = string.Format("You no longer have {0}!", d.DiseaseName);

					Zeus.QueueToOutput (output);
					// Debug.Log (output);

				}

			}

		}

		currentDiseasesToRemove.ForEach (x => CurrentDiseases.Remove (x));

	}

	public bool CheckIfLifeHasDisease(string diseaseName) {

		foreach (Disease d in CurrentDiseases) {

			if (diseaseName == d.DiseaseName) {

				return true;

			}

		}

		return false;

	}

	public bool CheckIfLifeHasVaccination(string diseaseName, out float reducedChanceToContract) {

		reducedChanceToContract = 0f;

		foreach (Vaccination v in CurrentVaccines) {

			if (diseaseName == v.Disease) {

				reducedChanceToContract = v.ReducedChanceToContractDisease;
				return true;

			}

		}

		return false;

	}

}

public enum Sexuality	{ NULL, HETEROSEXUAL, BISEXUAL, HOMOSEXUAL }
public enum Gender		{ MALE, FEMALE }