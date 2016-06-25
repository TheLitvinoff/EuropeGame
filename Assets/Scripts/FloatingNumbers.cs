using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour {

	[SerializeField]
	private float moveSpeed;
	public int damageGiven;
	[SerializeField]
	private Text displayDamage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		displayDamage.text = "-" + damageGiven;
		transform.position = new Vector3 (transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
	}
}
