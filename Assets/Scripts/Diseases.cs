using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diseases : MonoBehaviour {

	// ISO Alpha-3, English Country Name, Nationality
	public static List<Disease> List = new List<Disease> {

		// TODO: Finish this list, check what nationality people are, find and complete currency names & symbols, exchange rates and general cost of living.

		{ new Disease("Invisibility", "Inuisibilitas", "Patients suffer no discomfort. Indeed, many use the condition to play practical jokes on their families.",
			new string[] { "Whole Body" }, 240, 1) },
		{ new Disease("Invisibility Fatal", "Inuisibilitas Fatalus", "Patients suffers massive discomfort. They totes dead.",
			new string[] { "Whole Body" }, 120, 0.01f, 0.5f ) },
		
	};

}

[System.Serializable]
public class Disease {

	public string DiseaseName, LatinName, Description;
	public string[] AffectedBodyParts;
	public int AverageAgeToContract, AverageLength;
	public int MaximumAgeToContract;
	public bool CanBeTreated, CanBeCured;
	public float ChanceToContractPerMonth, IncreasedChanceToDie;

	/// <summary>
	/// Initializes a new instance of the <see cref="Disease"/> class.
	/// </summary>
	/// <param name="diseaseName">Disease name.</param>
	/// <param name="latinName">Latin name.</param>
	/// <param name="description">Description.</param>
	/// <param name="affectedBodyParts">Affected body parts.</param>
	/// <param name="averageAgeToContract">Average age to contract.</param>
	/// <param name="averageLength">Average length.</param>
	/// <param name="chanceToContractPerMonth">Chance to contract per month, IN RAW PERCENTAGE OUT OF 100.</param>
	/// <param name="increasedChanceToDie">Increased chance to die.</param>
	/// <param name="canBeTreated">If set to <c>true</c> can be treated.</param>
	/// <param name="canBeCured">If set to <c>true</c> can be cured.</param>
	public Disease(string diseaseName, string latinName, string description, string[] affectedBodyParts,
		int averageAgeToContract, int averageLength, 
		float chanceToContractPerMonth = 0.001f, float increasedChanceToDie = 0f,
		bool canBeTreated = true, bool canBeCured = true) {

		DiseaseName = diseaseName;
		LatinName = latinName;
		Description = description;
		AverageLength = averageLength;
		AverageAgeToContract = averageAgeToContract;
		AffectedBodyParts = affectedBodyParts;
		ChanceToContractPerMonth = chanceToContractPerMonth;
		IncreasedChanceToDie = increasedChanceToDie;
		CanBeTreated = canBeTreated;
		CanBeCured = canBeCured;
		MaximumAgeToContract = -1;

	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Disease"/> class, this class should only be used for childhood illnesses due to it defaulting to lifetime AverageLength.
	/// </summary>
	/// <param name="diseaseName">Disease name.</param>
	/// <param name="latinName">Latin name.</param>
	/// <param name="description">Description.</param>
	/// <param name="affectedBodyParts">Affected body parts.</param>
	/// <param name="maximumAgeToContract">Maximum age to contract.</param>
	/// <param name="chanceToContractPerMonth">Chance to contract per month, IN RAW PERCENTAGE OUT OF 100.</param>
	/// <param name="increasedChanceToDie">Increased chance to die.</param>
	/// <param name="canBeTreated">If set to <c>true</c> can be treated.</param>
	/// <param name="canBeCured">If set to <c>true</c> can be cured.</param>
	public Disease(string diseaseName, string latinName, string description, string[] affectedBodyParts,
		int maximumAgeToContract, float chanceToContractPerMonth, float increasedChanceToDie, int averageLength = 5000,
		bool canBeTreated = true, bool canBeCured = true) {

		DiseaseName = diseaseName;
		LatinName = latinName;
		Description = description;
		MaximumAgeToContract = maximumAgeToContract;
		AffectedBodyParts = affectedBodyParts;
		ChanceToContractPerMonth = chanceToContractPerMonth;
		IncreasedChanceToDie = increasedChanceToDie;
		AverageLength = averageLength;
		CanBeTreated = canBeTreated;
		CanBeCured = canBeCured;
		AverageAgeToContract = -1;

	}

}