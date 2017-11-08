using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MajorEventsUIController : MonoBehaviour {

	public RectTransform parent;
	public Button ButtonPrefab;

	public GameObject MajorEventDetails_Panel;

	List<MajorEvent> thisPageEvents = new List<MajorEvent>();

	int currentPage, supposedMaxPage, maxButtonsPerPage = 6;

	void OnEnable () {

		if (Zeus.Current == null || Zeus.Current.Player == null) {

			return;

		}

		currentPage = 0;
		supposedMaxPage = Mathf.CeilToInt ((float) Zeus.Current.Player.MajorEvents.Count / (float) maxButtonsPerPage) - 1;

		if (Zeus.Current == null) {

			return;

		}

		if (Zeus.Current.Player == null) {

			return;

		}

		DestroyAllButtons ();
		PopulateList ();	
		PopulateButtons ();

	}

	void OnDisable() {

		DestroyAllButtons ();

	}

	void DestroyAllButtons() {

		foreach (Button go in parent.GetComponentsInChildren<Button>()) {

			Destroy (go.gameObject);

		}

	}

	void PopulateList() {
		
		if (Zeus.Current == null || Zeus.Current.Player == null) {

			return;

		}

		thisPageEvents.Clear ();

		for (int i = (currentPage * maxButtonsPerPage); i < (maxButtonsPerPage * currentPage) + maxButtonsPerPage; i++) {

			if (i > Zeus.Current.Player.MajorEvents.Count - 1) {

				break;

			}

			thisPageEvents.Add (Zeus.Current.Player.MajorEvents [i]);

		}

	}

	void PopulateButtons() {

		if (Zeus.Current == null || Zeus.Current.Player == null) {

			return;

		}

		foreach (MajorEvent me in thisPageEvents) {

			Button current = Instantiate (ButtonPrefab, parent.transform) as Button;

			current.GetComponentInChildren<Text> ().text = me.EventName;
			current.onClick.AddListener(delegate { ButtonOnClick (me); });

		}

	}

	public void NextPageination() {

		currentPage++;

		if (currentPage > supposedMaxPage) {

			currentPage = supposedMaxPage;

		}
			
		DestroyAllButtons ();
		PopulateList ();
		PopulateButtons ();

	}
	public void PreviousPageination() {

		currentPage--;

		if (currentPage < 0) {

			currentPage = 0;

		}

		DestroyAllButtons ();
		PopulateList ();
		PopulateButtons ();	

	}

	void ButtonOnClick(MajorEvent me) {

		Debug.Log (string.Format ("Would open the MajorEventsDetails_Panel and show: {0}", me.EventName));

		if (MajorEventDetails_Panel == null) {

			return;

		}

		Text text = MajorEventDetails_Panel.GetComponent<Text> ();

		text.text = "blah blah";


	}

}
