using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MajorEventsUIController : MonoBehaviour {

	public RectTransform parent;
	public Button MajorEventsPrefab;

	List<MajorEvent> thisPageEvents = new List<MajorEvent>();

	int currentPage, supposedMaxPage, maxButtonsPerPage = 5;

	void OnEnable () {

		if (Zeus.Current == null) {

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

		thisPageEvents.Clear ();

		for (int i = (currentPage * maxButtonsPerPage); i < (maxButtonsPerPage * currentPage) + maxButtonsPerPage; i++) {

			if (i > Zeus.Current.Player.MajorEvents.Count - 1) {

				break;

			}

			thisPageEvents.Add (Zeus.Current.Player.MajorEvents [i]);

		}

	}

	void PopulateButtons() {

		foreach (MajorEvent me in thisPageEvents) {

			Button current = Instantiate (MajorEventsPrefab, parent.transform) as Button;

			current.GetComponentInChildren<Text> ().text = me.EventName;

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

}
