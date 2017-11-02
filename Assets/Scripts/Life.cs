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
	NationalityDetails nationality;
	[SerializeField]
	bool isDead;

	public string FirstName			{	get { return firstname; 		}	set { firstname = value; 		} 	}
	public string Surname			{	get { return surname; 			}	set { surname = value; 			} 	}
	public Gender Gender			{	get { return gender; 			}	set { gender = value; 			}	}
	public Sexuality Sexuality		{	get { return sexuality;			}	set { sexuality = value; 		} 	}
	public int Age					{	get { return age;				}	set { age = value; 				} 	} // THIS IS IN MONTHS!
	public int AgeInYears			{	get { return ageInYears;		}	set { ageInYears = value; 		} 	}
	public bool IsDead				{	get { return isDead;			}	set { isDead = value; 		} 	}

	public NationalityDetails Nationality	{	get { return nationality; }	set { nationality = value;	} 	}

	// Basic Stats
	[Range(0, 100)][SerializeField]
	float happiness, appearance, fitness, intellect;

	public float Happiness	{	get { return happiness;		}	set { happiness = value; 	} 	}
	public float Appearance	{	get { return appearance;	}	set { appearance = value; 	}	}
	public float Fitness 	{	get { return fitness;		}	set { fitness = value; 		}	}
	public float Intellect 	{	get { return intellect;		}	set { intellect = value; 	}	}

	void Update() {

		AgeInYears = Age / 12;

	}

	protected virtual void Die() {

		IsDead = true;

		// Life has died, if it's a parent or spouse then show a dialogue box and set the appropriate details in game,
		//	If it's the player, disable all Aging buttons and give them a summery of their life while allowing them to see
		//	what they accomlished in other tabs.

	}

	public virtual void ProcessAging() {

		if (!IsDead) {

			Age++;

		}

		if (Age == Constants.LIFE_ABSOLUTE_MAX_AGE_IN_MONTHS) {

			Die ();

		}

	}

}

public enum Sexuality	{ NULL, HETEROSEXUAL, BISEXUAL, HOMOSEXUAL }
public enum Gender		{ MALE, FEMALE }