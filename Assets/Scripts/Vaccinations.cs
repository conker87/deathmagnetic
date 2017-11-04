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
				new Vaccination("Seasonal Flu", "Seasonal Influenza", 8, 168)
			}
		},
	};

}

[System.Serializable]
public class Vaccination {

	public string Vaccine;
	public string Disease;
	public int Age;
	public int MaxProtectionTime;
	public bool Expired;
	public bool Missed;

	public Vaccination(string vaccine, string disease, int maxProtectionTime, int age, bool expired, bool missed) {

		Vaccine = vaccine;
		Disease = disease;
		Age = age;
		MaxProtectionTime = maxProtectionTime;
		Expired = expired;
		Missed = missed;

	}

	public Vaccination(string vaccine, string disease, int maxProtectionTime, int age, bool expired) {

		Vaccine = vaccine;
		Disease = disease;
		Age = age;
		MaxProtectionTime = maxProtectionTime;
		Expired = expired;
		Missed = false;

	}

	public Vaccination(string vaccine, string disease, int maxProtectionTime, int age) {

		Vaccine = vaccine;
		Disease = disease;
		Age = age;
		MaxProtectionTime = maxProtectionTime;
		Expired = false;
		Missed = false;

	}

}
