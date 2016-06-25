using UnityEngine;
using System.Collections;
using UnityEngine.UI;
    
public class UIManager : MonoBehaviour {

	[SerializeField]
	private Slider healthBar;
	[SerializeField]
	private Text HPText;
	[SerializeField]
	private PlayerHealthManager playerHealth;

	private static bool UIExists;

	// Use this for initialization
	void Start () {
		if (!UIExists)
		{
			UIExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		healthBar.maxValue = playerHealth.maxHealth;
		healthBar.value = playerHealth.currentHealth;
		HPText.text = "HP: " + playerHealth.currentHealth + "/" + playerHealth.maxHealth;
	}
}
