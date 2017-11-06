using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Athena : MonoBehaviour {

	public void ToggleUIPanels(GameObject panel) {

		panel.SetActive (!panel.activeInHierarchy);

	}

}
