using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccinations {

	// public static Dictionary<string, Vaccination[]> Dictionary = new Dictionary<string, Vaccination[]> {
	public static List<Vaccination[]> List = new List<Vaccination[]> {

		{ new Vaccination[] {
				new Vaccination("Rotavirus", "Rotavirus Infection", 5000, 3)
			}
		},
		{ new Vaccination[] {
				new Vaccination("6-in-1", "Diphtheria", 32, 4),
				new Vaccination("6-in-1", "Tetanus", 32, 4),
				new Vaccination("6-in-1", "Whooping Cough", 32, 4),
				new Vaccination("6-in-1", "Polio", 32, 4),
				new Vaccination("6-in-1", "Haemophilus Influenzae Type B", 8, 4),
				new Vaccination("6-in-1", "Hepatitis B", 44, 4),
			}
		},
		{ new Vaccination[] {
				new Vaccination("Men B", "Meningitis B", 5000, 12)
			}
		},
		{ new Vaccination[] {
				new Vaccination("Hib/Men C", "Haemophilus Influenzae Type B", 5000, 12),
				new Vaccination("Hib/Men C", "Meningitis C", 158, 12)
			}
		},
		{ new Vaccination[] {
				new Vaccination("MMR", "Measles", 5000, 36),
				new Vaccination("MMR", "Mumps", 5000, 36),
				new Vaccination("MMR", "Rubella", 5000, 36)
			}
		},
		{ new Vaccination[] {
				new Vaccination("4-in-1", "Diphtheria", 132, 36),
				new Vaccination("4-in-1", "Tetanus", 132, 36),
				new Vaccination("4-in-1", "Whooping cough", 5000, 36),
				new Vaccination("4-in-1", "Polio", 132, 36)
			}
		},
		{ new Vaccination[] {
				new Vaccination("HPV", "HPV", 5000, 144)
			}
		},
		{ new Vaccination[] {
				new Vaccination("3-in-1", "Diphtheria", 5000, 168),
				new Vaccination("3-in-1", "Tetanus", 5000, 168),
				new Vaccination("3-in-1", "Polio", 5000, 168)
			}
		},
		{ new Vaccination[] {
				new Vaccination("Men ACWY", "Meningitis A", 5000, 168),
				new Vaccination("Men ACWY", "Meningitis C", 5000, 168),
				new Vaccination("Men ACWY", "Meningitis W", 5000, 168),
				new Vaccination("Men ACWY", "Meningitis Y", 5000, 168)
			}
		},
		{ new Vaccination[] {
				new Vaccination("Seasonal Flu", "Seasonal Influenza", 8, 168, 3f)
			}
		},
	};

}

[System.Serializable]
public class Vaccination {

	public string Vaccine;
	public string Disease;
	public int MaxProtectionTime;
	public int AgeImmunised;
	public float ReducedChanceToContractDisease;
	public bool Expired;
	public bool Missed;

	/// <summary>
	/// Initializes a new instance of the <see cref="Vaccination"/> class.
	/// </summary>
	/// <param name="vaccine">Vaccine.</param>
	/// <param name="disease">Disease.</param>
	/// <param name="maxProtectionTime">Max protection time.</param>
	/// <param name="age">Age.</param>
	/// <param name="reducedChanceToContractDisease">Reduced chance to contract disease, the chance is divided by this number.</param>
	/// <param name="expired">If set to <c>true</c> expired.</param>
	/// <param name="missed">If set to <c>true</c> missed.</param>
	public Vaccination(string vaccine, string disease, int maxProtectionTime, int age, float reducedChanceToContractDisease = -1f, bool expired = false, bool missed = false) {

		Vaccine = vaccine;
		Disease = disease;
		MaxProtectionTime = maxProtectionTime;
		AgeImmunised = age;
		ReducedChanceToContractDisease = reducedChanceToContractDisease;
		Expired = expired;
		Missed = missed;

	}

	public Vaccination(Vaccination vaccination) {

		Vaccine = vaccination.Vaccine;
		Disease = vaccination.Disease;
		MaxProtectionTime = vaccination.MaxProtectionTime;
		AgeImmunised = vaccination.AgeImmunised;
		ReducedChanceToContractDisease = vaccination.ReducedChanceToContractDisease;
		Expired = vaccination.Expired;
		Missed = vaccination.Missed;

	}

	public Vaccination() {


	}

}
