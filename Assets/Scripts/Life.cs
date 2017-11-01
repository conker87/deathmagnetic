using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	#region Singleton
	public static Life Current = null;

	void Awake() {

		if (Current == null) {
			Current = this;
		} else if (Current != this) {
			Destroy (gameObject);    
		}

		DontDestroyOnLoad(gameObject);

	}
	#endregion

	// Vitals
	string firstname, surname, gender, snationality, sexuality, mother_name, father_name;
	NationalityDetails nationalityDetails;

	public string FirstName		{	get { return firstname; }		set { firstname = value; } 	}
	public string Surname		{	get { return surname; }			set { surname = value; } 	}
	public string Gender		{	get { return gender; }			set { gender = value; } 	}
	public string sNationality	{	get { return snationality; }	set { snationality = value; } 	}
	public string Sexuality		{	get { return sexuality; }		set { sexuality = value; } 	}
	public string Mother_Name	{	get { return mother_name; }		set { mother_name = value; } 	}
	public string Father_Name	{	get { return father_name; }		set { father_name = value; } 	}

	// Basic Stats
	[Range(0, 100)]
	float happiness, appearance, fitness, intellect;

	public float Happiness	{	get { return happiness; }	set { happiness = value; } 	}
	public float Appearance	{	get { return appearance; }	set { appearance = value; }	}
	public float Fitness 	{	get { return fitness; }		set { fitness = value; }	}
	public float Intellect 	{	get { return intellect; }	set { intellect = value; }	}

	// Learnable skills
	[Range(0, 100)]
	float guitar, piano, violin, art, talking, building;
		// Add more?

	public float Guitar 	{	get { return guitar; }	set { guitar = value; }		}
	public float Piano 		{	get { return piano; }	set { piano = value; }		}
	public float Violin 	{	get { return violin; }	set { violin = value; }		}
	public float Art 		{	get { return art; }		set { art = value; }		}
	public float Talking 	{	get { return talking; }	set { talking = value; }	}
	public float Building 	{	get { return building; }set { building = value; }	}

	public void Birth() {

		ResetSkills ();

	}

	public void Suicide() {

		// Destroy and regen all data related to the current Life.

	}

	void SetNationality() {

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

	void ResetSkills() {

		SetNationality ();

		// Replacing values with default just been born values;
		Happiness = 100f;
		Appearance = 50f;
		Fitness = 5f;
		Intellect = 10f;

		Guitar = Piano = Violin = Art = Talking = Building = 0f;

	}

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
		
	}

}

public enum Sexuality { HETEROSEXUAL, BISEXUAL, HOMOSEXUAL }
// public enum Nationality { USA }