using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Zeus : MonoBehaviour {

	#region Singleton
	public static Zeus Current = null;

	void Awake() {

		if (Current == null) {
			Current = this;
		} else if (Current != this) {
			Destroy (gameObject);    
		}

		DontDestroyOnLoad(gameObject);

	}
	#endregion

	public Player Player;
	public Spouse Spouse;
	public Parent Mother, Father;

	public static List<string> ToUpdateOutput = new List<string> ();
	public List<string> toUpdateOutput = new List<string>();

	//public Text Output;
	//static Text output;

	public TextMeshProUGUI Output;
	static TextMeshProUGUI output;

	public RectTransform OutputScrollRect;
	static RectTransform outputScrollRect;

	public Scrollbar VerticalScrollBar;
	static Scrollbar verticalScrollBar;

	public ScrollRect ScrollViewRect;
	static ScrollRect scrollViewRect;

	// This is for all the choices the user can pick, all choices need to be added to this array and removed once the
	//	user has picked.
	// DialogueBox[] queuedDialogueBoxes;

	public void CreateNewLife() {

		if (Mother != null) {

			Destroy (Mother);
			Mother = null;

		}

		if (Father != null) {

			Destroy (Father);
			Father = null;

		}

		if (Player != null) {

			Destroy (Player);
			Player = null;

		}

		Destroy (Spouse);

		Mother = gameObject.AddComponent<Parent> ();
		Mother.ParentType = ParentType.MOTHER;
		Mother.FirstName = "Mother";
		Mother.LastName = "Parent";
		Mother.Create ();

		Father = gameObject.AddComponent<Parent> ();
		Father.ParentType = ParentType.FATHER;
		Father.FirstName = "Father";
		Father.LastName = "Parent";
		Father.Create ();

		// TODO: Try and remember the word instead of lifetime.
		Mother.CurrentVaccines.Add (new Vaccination ("Lifetime? Immunity", "All Vaccines", -1, 5000));
		Father.CurrentVaccines = Mother.CurrentVaccines;

		// For testing purposes.
		Mother.Intellect = Father.Intellect = 100f;

		Player = gameObject.AddComponent<Player> ();
		Player.FirstName = "Player";
		Player.LastName = "LastName";
		Player.Create ();

		PostToOutput ();

	}

	public void AgeMonth(int monthsToAge) {

		if (Player == null || Mother == null || Father == null) {

			return;

		}

		int i = 0;
		float timeBefore = 0f, timeAfter = 0f;


		while (monthsToAge > i) {

			float timeProcessBefore = 0f, timeProcessAfter = 0f;

			timeProcessBefore = Time.time;
			Player.ProcessAging ();
			timeProcessAfter = Time.time;
			Debug.Log (string.Format("Player.ProcessAging () took: {0} ms.", timeProcessAfter - timeProcessBefore));

			if (Spouse != null) Spouse.ProcessAging ();

			timeProcessBefore = Time.time;
			Mother.ProcessAging ();
			timeProcessAfter = Time.time;
			Debug.Log (string.Format("Mother.ProcessAging () took: {0} ms.", timeProcessAfter - timeProcessBefore));

			timeProcessBefore = Time.time;
			Father.ProcessAging ();
			timeProcessAfter = Time.time;
			Debug.Log (string.Format("Father.ProcessAging () took: {0} ms.", timeProcessAfter - timeProcessBefore));

			i++;

		}

		PostToOutput ();

		timeAfter = Time.time;

		Debug.Log (string.Format("This iteration took: {0} ms.", timeAfter - timeBefore));

	}

	public void LearningGuitarToggle() {

		if (Player == null) {

			return;

		}

		if (Player.Age < Constants.LIFE_MIN_AGE_TO_GUITAR) {

			return;

		}

		if (!Player.LearningGuitar) {

			Player.LearningGuitar = true;
			if (!Player.startedGuitar.Contains (Player.Age)) {
				Player.startedGuitar.Add (Player.Age);
			}

		} else {

			Player.LearningGuitar = false;

		}

	}

	public void IsStudyingToggle() {

		if (Player.Age < Constants.LIFE_MIN_AGE_TO_STUDY) {

			return;

		}

		Player.IsStudying = !Player.IsStudying;

		// TODO: Tweak these values, as it's a little too much.
		if (Player.IsStudying) {

			Player.intellectModifier.Add (Constants.SKILL_STUDYING_MODIFIER_MOD);

		} else {

			Player.intellectModifier.Remove (Constants.SKILL_STUDYING_MODIFIER_MOD);

		}

	}

	public void _DEBUG_GiveVaccination(Vaccination[] vaccinations) {

		Player.CurrentVaccines.AddRange (vaccinations);

	}

	public void _DEBUG_testVaccines() {

		Player.ProcessVaccines();

	}

	public static float CalculateBaseChanceToRandomlyDie(int age) {

		float coeffient = 1.00001f;

		// TODO: These possibly still need tweaking, play-testing is needed.
		if (age >= 0) {

			coeffient = 1.00001f;
		}
		if (age >= (20*12)) {

			coeffient = 1.000011f;
		}
		if (age >= (40*12)) {

			coeffient = 1.000012f;
		}
		if (age >= (60*12)) {

			coeffient = 1.00002f;
		}
		if (age >= (80*12)) {

			coeffient = 1.00025f;
		}
		if (age >= (100*12)) {

			coeffient = 1.0005f;
		}
		if (age >= Constants.LIFE_ABSOLUTE_MAX_AGE_IN_MONTHS) {

			coeffient = 2f;

		}

		return (Mathf.Pow (coeffient, age) - 1f) / 100f;

	}

	public static Nationality SetNationality() {

		return Nationalities.List[Random.Range(0, Nationalities.List.Count)];;

	}

	public void _DEBUG_TestOutputStatic() {

		int iterations = 250;

		for (int i = 0; i < iterations; i++) {

			QueueToOutput (string.Format("New Line Test: {0}", i), 1);

		}

	}

	public static void QueueToOutput(string text = "", int newLines = 1) {

		if (output == null || outputScrollRect == null) {

			return;

		}

		string temp = "";

		if (newLines > 0) {

			for (int i = 0; i < newLines; i++) {

				temp += "\n";

				// outputScrollRect.sizeDelta = new Vector2 (outputScrollRect.sizeDelta.x, outputScrollRect.sizeDelta.y + 45f);
			}

		}

		temp += text;

		ToUpdateOutput.Add (temp);

		CheckOutputLength ();

	}

	static void PostToOutput() {

		ToUpdateOutput.ForEach (x => output.text += x);
		ToUpdateOutput.Clear ();

		Canvas.ForceUpdateCanvases();
		scrollViewRect.verticalNormalizedPosition = 0f;
		Canvas.ForceUpdateCanvases();

	}

	/* public static void PostToOutput(string text = "", int newLines = 1) {

		if (output == null || outputScrollRect == null) {

			return;

		}

		if (newLines > 0) {

			for (int i = 0; i < newLines; i++) {

				if (output.text == "") {
					continue;
				}

				output.text += "\n";

				// outputScrollRect.sizeDelta = new Vector2 (outputScrollRect.sizeDelta.x, outputScrollRect.sizeDelta.y + 45f);
			}

		}

		output.text += text;

		CheckOutputLength ();

		//Canvas.ForceUpdateCanvases();
		//scrollViewRect.verticalNormalizedPosition = 0f;
		//Canvas.ForceUpdateCanvases();

	} */

	static void CheckOutputLength() {

		if (output.text.Length > Constants.TEXT_CHARACTER_LIMIT) {

			int limit = output.text.Length - Constants.TEXT_CHARACTER_LIMIT;

			output.text = output.text.Remove (0, limit);

		}

	}

	public static void ResetOutput() {

		output.text = "";

	}

	public static string ToTitleCase(string stringToConvert) {

		string firstChar = stringToConvert[0].ToString();
		return (stringToConvert.Length > 0 ? firstChar.ToUpper() + stringToConvert.Substring(1) : stringToConvert.ToLower());

	}

	void Start() {

		output = Output;
		outputScrollRect = OutputScrollRect;
		verticalScrollBar = VerticalScrollBar;
		scrollViewRect = ScrollViewRect;

	}

	// Update is called once per frame
	void Update () {
		// toUpdateOutput = ToUpdateOutput;
	}
}