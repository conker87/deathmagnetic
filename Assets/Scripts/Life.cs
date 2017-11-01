using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	// Vitals
	string firstname, surname, snationality;
	Parent mother, father;
	int age;
	Gender gender;
	Sexuality sexuality;
	NationalityDetails nationalityDetails;

	public string FirstName		{	get { return firstname; 	}	set { firstname = value; 	} 	}
	public string Surname		{	get { return surname; 		}	set { surname = value; 		} 	}
	public Gender Gender		{	get { return gender; 		}	set { gender = value; 		}	}
	public Parent Mother		{	get { return mother; 		}	set { mother = value; 		} 	}
	public Parent Father		{	get { return father; 		}	set { father = value; 		} 	}
	public string sNationality	{	get { return snationality; 	}	set { snationality = value; } 	}
	public Sexuality Sexuality	{	get { return sexuality;		}	set { sexuality = value; 	} 	}
	public int Age				{	get { return age;			}	set { age = value; 			} 	} // THIS IS IN MONTHS!

	public NationalityDetails NationalityDetails	{	get { return nationalityDetails; }	set { nationalityDetails = value; 			} 	} !

	// Basic Stats
	[Range(0, 100)]
	float happiness, appearance, fitness, intellect;

	public float Happiness	{	get { return happiness;		}	set { happiness = value; 	} 	}
	public float Appearance	{	get { return appearance;	}	set { appearance = value; 	}	}
	public float Fitness 	{	get { return fitness;		}	set { fitness = value; 		}	}
	public float Intellect 	{	get { return intellect;		}	set { intellect = value; 	}	}

	protected virtual void SetVitals() { 

		FirstName = "Testie";					// TODO: Randomly picknames depending on Nationality.
		Surname = "McTesterson";

		Gender = (Random.value > 0.5f) ? Gender.MALE : Gender.FEMALE;

	}

	protected virtual void SetBasicStats() {

		// Replacing values with default just been born values;
		Happiness = 100f;
		Appearance = 50f;
		Fitness = 5f;
		Intellect = 10f;

	}

	protected void SetNationality() {

		// Picking a random dictionary keypair by putting the Keys into a list, getting a random value from there
		//		and putting the return value into the original dictionary.

		List<string> keyList = new List<string> (Nationality.Nationalities.Keys);

		sNationality = keyList[Random.Range(0, keyList.Count)];
		nationalityDetails = Nationality.Nationalities [sNationality];

		if (nationalityDetails != null) {

			Debug.Log (string.Format ("Nationality picked as: {0}, you're from {1}, the code is: {2}. Your currency is {3}, and the format is: {4}4,000{5}",
				nationalityDetails.Nationality, nationalityDetails.CountryName,
				sNationality, nationalityDetails.CurrencyName,
				nationalityDetails.CurrencyStringPrefix, nationalityDetails.CurrencyStringSuffix));

		}

	}

}

public enum Sexuality	{ HETEROSEXUAL, BISEXUAL, HOMOSEXUAL }
public enum Gender		{ MALE, FEMALE }