using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	// Vitals
	[SerializeField]
	string firstname, surname, nationalityCode;
	[SerializeField]
	int age, ageInYears;
	[SerializeField]
	Gender gender;
	[SerializeField]
	Sexuality sexuality;
	[SerializeField]
	NationalityDetails nationalityDetails;

	public string FirstName			{	get { return firstname; 		}	set { firstname = value; 		} 	}
	public string Surname			{	get { return surname; 			}	set { surname = value; 			} 	}
	public Gender Gender			{	get { return gender; 			}	set { gender = value; 			}	}
	public string NationalityCode	{	get { return nationalityCode; 	}	set { nationalityCode = value; 	} 	}
	public Sexuality Sexuality		{	get { return sexuality;			}	set { sexuality = value; 		} 	}
	public int Age					{	get { return age;				}	set { age = value; 				} 	} // THIS IS IN MONTHS!
	public int AgeInYears			{	get { return ageInYears;		}	set { ageInYears = value; 		} 	}

	public NationalityDetails NationalityDetails	{	get { return nationalityDetails; }	set { nationalityDetails = value;	} 	}

	// Basic Stats
	[Range(0, 100)]
	float happiness, appearance, fitness, intellect;

	public float Happiness	{	get { return happiness;		}	set { happiness = value; 	} 	}
	public float Appearance	{	get { return appearance;	}	set { appearance = value; 	}	}
	public float Fitness 	{	get { return fitness;		}	set { fitness = value; 		}	}
	public float Intellect 	{	get { return intellect;		}	set { intellect = value; 	}	}

	protected virtual void SetBirthStats() {

		Happiness = 100f;
		Appearance = 50f;
		Fitness = 5f;
		Intellect = 10f;

	}

	void Update() {

		AgeInYears = Age / 12;

	}

}

public enum Sexuality	{ HETEROSEXUAL, BISEXUAL, HOMOSEXUAL }
public enum Gender		{ MALE, FEMALE }