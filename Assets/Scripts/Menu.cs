using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Canvas exitMenu;
	public Button playButton;
	public Button exitButton;	

	// Use this for initialization
	void Start () {
		exitMenu.enabled = false;
		exitMenu = exitMenu.GetComponent<Canvas> ();
		playButton = playButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ExitPress() {
		exitMenu.enabled = true;
		playButton.enabled = false;
		exitButton.enabled = false;
	}

	public void NoPress() {
		exitMenu.enabled = false;
		playButton.enabled = true;
		exitButton.enabled = true;
	}

	public void StartLevel() {
		Application.LoadLevel(1);
	}

	public void ExitGame() {
		Application.Quit();
	}
}
