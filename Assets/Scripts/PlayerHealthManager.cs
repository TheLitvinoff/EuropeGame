using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (currentHealth <= 0) {
			gameObject.SetActive(false);
		}
	}

	public void HurtPlayer(int damageToGive) {
		currentHealth -= damageToGive;
	}

	public void SetMaxHealth() {
		currentHealth = maxHealth;
	}
}
