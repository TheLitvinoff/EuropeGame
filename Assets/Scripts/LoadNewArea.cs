using UnityEngine;
using System.Collections;

public class LoadNewArea : MonoBehaviour {

    [SerializeField]
    private string levelToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}
