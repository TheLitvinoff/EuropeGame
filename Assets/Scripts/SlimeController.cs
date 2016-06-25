using UnityEngine;
using System.Collections;

public class SlimeController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;
    private Rigidbody2D slimeRigBody;
    private bool moving;

    [SerializeField]
    private float timeBetweenMove;
    private float timeBetweenMoveCounter;
    [SerializeField]
    private float timeMoving;
    private float timeMovingCounter;

    private Vector3 moveDirection;

    [SerializeField]
    private float waitToReload;
    private bool reloading;

    private GameObject player;

	public Canvas messageWhenPlayerDied;

    // Use this for initialization
    void Start () {
		messageWhenPlayerDied.enabled = false;

		player = GameObject.Find("Player");

        slimeRigBody = GetComponent<Rigidbody2D>(); 

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeMovingCounter = Random.Range(timeMoving * 0.75f, timeMoving * 1.25f);

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        HandleMovement();
		HandleReload();
    }

    void HandleMovement()
    {
        if (moving)
        {
            timeMovingCounter -= Time.deltaTime;
            slimeRigBody.velocity = moveDirection;

            if (timeMovingCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            slimeRigBody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeMovingCounter = Random.Range(timeMoving * 0.75f, timeMoving * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * movementSpeed, Random.Range(-1f, 1f) * movementSpeed, 0f);
            }
        }
    }

    void HandleReload()
    {
		if (!player.activeSelf) {
			reloading = true;
			messageWhenPlayerDied.enabled = true;
		}

        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0f)
            {
                Application.LoadLevel(Application.loadedLevel);
				player.GetComponent<PlayerHealthManager>().SetMaxHealth();
				messageWhenPlayerDied.enabled = false;
                player.SetActive(true);
				reloading = false;
            }
        }
    }
}
