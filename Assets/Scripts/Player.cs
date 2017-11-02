using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Life {

	// Player only vitals
	[SerializeField]
	Parent mother, father;

	public Parent Mother			{	get { return mother; 			}	set { mother = value; 			} 	}
	public Parent Father			{	get { return father; 			}	set { father = value; 			} 	}

	[SerializeField]
	bool amAdopted = false;

	public bool AmAdopted			{	get { return amAdopted; 		}	set { amAdopted = value; 		} 	}

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

	public void Create() {



	}

	void ResetSkills() {

		Guitar = Piano = Violin = Art = Talking = Building = 0f;

	}

	public void Birth() {

		SetBirthStats ();

		ResetSkills ();

	}

	public void Suicide() {

		Zeus.Current.CreateNewLife ();

	}

	// Use this for initialization
	void Start () {

		Debug.Log ("Life::Player -- Start()");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
