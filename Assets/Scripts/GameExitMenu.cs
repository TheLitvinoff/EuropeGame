using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameExitMenu : MonoBehaviour {

	public Canvas exitMenu;

	// Use this for initialization
	void Start () {
		exitMenu.enabled = false;		
	}

	// Update is called once per frame
	void Update () {
		HandleExitMenu ();
	}

	void HandleExitMenu() {
		if (exitMenu.enabled) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				exitMenu.enabled = false;
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				exitMenu.enabled = true;
			}
		}
	}

	public void NoPress() {
		exitMenu.enabled = false;
	}

	public void YesPress() {
		Application.Quit();
	}
}
