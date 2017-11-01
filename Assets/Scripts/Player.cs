using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Life {

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

	// Learnable skills
	[Range(0, 100)]
	float guitar, piano, violin, art, talking, building;
	// Add more?

	public float Guitar 	{	get { return guitar; 	}	set { guitar = value; 	}	}
	public float Piano 		{	get { return piano; 	}	set { piano = value; 	}	}
	public float Violin 	{	get { return violin; 	}	set { violin = value; 	}	}
	public float Art 		{	get { return art; 		}	set { art = value; 		}	}
	public float Talking 	{	get { return talking; 	}	set { talking = value; 	}	}
	public float Building 	{	get { return building; 	}	set { building = value; }	}

	// Your current spouse, if any;
	Spouse spouse;

	public Spouse Spouse	{	get { return spouse; 	}	set { spouse = value; }	}

	void ResetSkills() {

		SetNationality ();

		Guitar = Piano = Violin = Art = Talking = Building = 0f;

	}

	public void Birth() {

		SetBasicStats ();

		ResetSkills ();

	}

	public void Suicide() {

		// Destroy and regen all data related to the current Life.

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
