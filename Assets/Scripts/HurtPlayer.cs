using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

	[SerializeField]
	private int damageToGive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Player")
        {
			other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive); 

        } 
	}

}
