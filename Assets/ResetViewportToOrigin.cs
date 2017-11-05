using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ResetViewportToOrigin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0f, 0f);

	}

	void OnEnable() {

		Start ();

	}


	void OnDisable() {

		Start ();

	}

	void OnApplicationQuit() {

		Start ();

	}

}
