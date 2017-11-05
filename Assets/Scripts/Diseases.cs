using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diseases : MonoBehaviour {

	// ISO Alpha-3, English Country Name, Nationality
	public static readonly List<Disease> List = new List<Disease> {

		// TODO: Finish this list, check what nationality people are, find and complete currency names & symbols, exchange rates and general cost of living.

		{ new Disease(DiseaseType.CONTRACT, "Invisibility", "Inuisibilitas", "Patients suffer no discomfort. Indeed, many use the condition to play practical jokes on their families.",
			new string[] { "Whole Body" }, 120) },
		{ new Disease(DiseaseType.BORN, "Invisibility Fatal", "Inuisibilitas Fatalus", "Patients suffers massive discomfort. They totes dead.",
			new string[] { "Whole Body" }, 5000) },
		{ new Disease(DiseaseType.BORN, "Testititus", "Testius Sharpus", "Testing.",
			new string[] { "Whole Body" }, 5, 0.5f) },
		{ new Disease(DiseaseType.CONTRACT, "Testititus Contract", "Testius Sharpus", "Testing.",
			new string[] { "Whole Body" }, 5, 0.5f) }
		
	};

}

[System.Serializable]
public class Disease {

	public DiseaseType DiseaseType;
	public string DiseaseName, LatinName, Description;
	public string[] AffectedBodyParts;
	public int AverageLength;
	public bool CanBeTreated, CanBeCured;
	public float ChanceToContract, IncreasedChanceToDie;

	public int AgeContracted = -1;

	/// <summary>
	/// Initializes a new instance of the <see cref="Disease"/> class.
	/// </summary>
	/// <param name="diseaseName">Disease name.</param>
	/// <param name="latinName">Latin name.</param>
	/// <param name="description">Description.</param>
	/// <param name="affectedBodyParts">Affected body parts.</param>
	/// <param name="averageAgeToContract">Average age to contract.</param>
	/// <param name="averageLength">Average length.</param>
	/// <param name="chanceToContractPerMonth">Chance to contract per month, as a percentage.</param>
	/// <param name="increasedChanceToDie">Increased chance to die, as a percentage.</param>
	/// <param name="canBeTreated">If set to <c>true</c> can be treated.</param>
	/// <param name="canBeCured">If set to <c>true</c> can be cured.</param>
	public Disease(DiseaseType diseaseType, string diseaseName, string latinName, string description, string[] affectedBodyParts,
		int averageLength,
		float chanceToContract = 0.001f, float increasedChanceToDie = 0f,
		bool canBeTreated = true, bool canBeCured = true) {

		DiseaseType = diseaseType;
		DiseaseName = diseaseName;
		LatinName = latinName;
		Description = description;
		AffectedBodyParts = affectedBodyParts;
		AverageLength = averageLength;
		ChanceToContract = chanceToContract;
		IncreasedChanceToDie = increasedChanceToDie;
		CanBeTreated = canBeTreated;
		CanBeCured = canBeCured;

		AgeContracted = -1;
	}

	public Disease (Disease disease) {

		DiseaseType = disease.DiseaseType;
		DiseaseName = disease.DiseaseName;
		LatinName = disease.LatinName;
		Description = disease.Description;
		AffectedBodyParts = disease.AffectedBodyParts;
		AverageLength = disease.AverageLength;
		ChanceToContract = disease.ChanceToContract;
		IncreasedChanceToDie = disease.IncreasedChanceToDie;
		CanBeTreated = disease.CanBeTreated;
		CanBeCured = disease.CanBeCured;

		AgeContracted = -1;

	}

	public Disease() {


	}

}

public enum DiseaseType { BORN, CONTRACT };