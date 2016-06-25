using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {

	[SerializeField]
	private int damageToGive;
	[SerializeField]
	private GameObject damageBusrt;
	[SerializeField]
	private Transform hitPoint;
	[SerializeField]
	private GameObject damageNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
			Instantiate (damageBusrt, hitPoint.position, hitPoint.rotation);

			var clone = (GameObject) Instantiate (damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageGiven = damageToGive;
		}
	}
}
