using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	[SerializeField]
	private int maxHealth;
	[SerializeField]
	private int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (currentHealth <= 0) {
			Destroy(gameObject);
		}
	}

	public void HurtEnemy(int damageToGive) {
		currentHealth -= damageToGive;
	}

	public void SetMaxHealth() {
		currentHealth = maxHealth;
	}
}