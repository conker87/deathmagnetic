using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	// Vitals
	[SerializeField]
	string firstname, surname;
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
	public string Surname			{	get { return surname; 			}	set { surname = value; 			} 	}
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

			deathChanceModifier.ForEach (x => chanceToDie += (x / 100f));

			if (ran < chanceToDie) {

				Die ();

			}

			if (this.FirstName == "Player") {
				Debug.Log (string.Format ("{0} (At Age: {3}/{4}: {1}% ({2}). Killed you? {5}", this.FirstName, chanceToDie * 100f, ran, Age, Age / 12, (ran < chanceToDie)));
			}

		}

		if (Age == Constants.LIFE_ABSOLUTE_MAX_AGE_IN_MONTHS) {

			Die ();

		}

		if (!IsDead) {

			Age++;

		}

	}

	protected virtual void ProcessDiseases() {

		foreach (Disease d in Diseases.List) {

			if (d.AverageAgeToContract != -1) {

				if (Random.value < (d.ChanceToContractPerMonth / 100)) {



				}

			}

			if (d.MaximumAgeToContract != -1) {



			}

		}

	}

}

public enum Sexuality	{ NULL, HETEROSEXUAL, BISEXUAL, HOMOSEXUAL }
public enum Gender		{ MALE, FEMALE }