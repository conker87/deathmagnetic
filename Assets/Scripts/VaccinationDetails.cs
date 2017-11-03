using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VaccinationDetails {
	
	public string Disease;
	public int Age, MaxProtectionTime;
	public bool AntiVax;

	public VaccinationDetails(string disease, int maxProtectionTime, int age, bool antiVax = false) {

		Disease = disease;
		Age = age;
		MaxProtectionTime = maxProtectionTime;
		AntiVax = antiVax;

	}

}


public class VaccineListDetails {

	public string Disease;
	public int Age;
	public int MaxProtectionTime;

	public VaccineListDetails(string disease, int maxProtectionTime, int age) {

		Disease = disease;
		Age = age;
		MaxProtectionTime = maxProtectionTime;

	}

}

public class VaccineList {

	public static Dictionary<string, VaccineListDetails[]> Vaccines = new Dictionary<string, VaccineListDetails[]> {

		{ "6-in-1", new VaccineListDetails[] {
				new VaccineListDetails("Diphtheria", 44, 4),
				new VaccineListDetails("Tetanus", 44, 4),
				new VaccineListDetails("Whooping Cough", 44, 4),
				new VaccineListDetails("Polio", 44, 4),
				new VaccineListDetails("Haemophilus Influenzae Type B", 44, 4),
				new VaccineListDetails("Hepatitis B", 44, 4),
			}
		},
		{ "PCV", new VaccineListDetails[] {
				new VaccineListDetails("Pneumococcal Infection", 5000, 12)
			}
		},
		{ "Rotavirus", new VaccineListDetails[] {
				new VaccineListDetails("Rotavirus Infection", 5000, 3)
			}
		},
		{ "Men B", new VaccineListDetails[] {
				new VaccineListDetails("Meningitis B", 5000, 12)
			}
		},
		{ "Hib/Men C", new VaccineListDetails[] {
				new VaccineListDetails("Haemophilus Influenzae Type B", 5000, 12),
				new VaccineListDetails("Meningitis C", 5000, 12)
			}
		},
		{ "MMR", new VaccineListDetails[] {
				new VaccineListDetails("Measles", 5000, 36),
				new VaccineListDetails("Mumps", 5000, 36),
				new VaccineListDetails("Rubella", 5000, 36)
			}
		},
		{ "4-in-1", new VaccineListDetails[] {
				new VaccineListDetails("Diphtheria", 140, 36),
				new VaccineListDetails("Tetanus", 140, 36),
				new VaccineListDetails("Whooping cough", 5000, 36),
				new VaccineListDetails("Polio", 140, 36)
			}
		},
		{ "HPV", new VaccineListDetails[] {
				new VaccineListDetails("HPV", 5000, 144)
			}
		},
		{ "3-in-1", new VaccineListDetails[] {
				new VaccineListDetails("Diphtheria", 5000, 36),
				new VaccineListDetails("Tetanus", 5000, 36),
				new VaccineListDetails("Polio", 5000, 36)
			}
		},
		{ "Men ACWY", new VaccineListDetails[] {
				new VaccineListDetails("Meningitis A", 5000, 168),
				new VaccineListDetails("Meningitis C", 5000, 168),
				new VaccineListDetails("Meningitis W", 5000, 168),
				new VaccineListDetails("Meningitis Y", 5000, 168)
			}
		},
		{ "Seasonal Flu", new VaccineListDetails[] {
				new VaccineListDetails("Seasonal Influenza", 7, 168)
			}
		},
	};

}