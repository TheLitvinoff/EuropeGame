using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float movementSpeed;
	private Animator charAnimator;
	private Rigidbody2D charRigBody;
	private bool charMoving;
	public Vector2 lastMove;
    private static bool playerExists;

	private bool charAttacking;
	[SerializeField]
	private float attackingTime;
	private float attackingTimeCounter;

	void Start () {
		charAnimator = GetComponent<Animator>();
		charRigBody = GetComponent<Rigidbody2D>();
        
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
        
	}

	void FixedUpdate () {
		float horizontalAxis = Input.GetAxisRaw ("Horizontal");
		float verticalAxis = Input.GetAxisRaw ("Vertical");

		if (!charAttacking) {
			HandleMovement(horizontalAxis, verticalAxis);
			HandleAttack();
			ResetValues();
		} else {
			HandleAttackCounter();
		}
	}

	void HandleMovement(float horizontal, float vertical) {
		if (horizontal != 0f) {
			//transform.Translate (new Vector3(horizontal * movementSpeed * Time.deltaTime, 0f, 0f));

			charRigBody.velocity = new Vector2(horizontal * movementSpeed, charRigBody.velocity.y);

			charMoving = true;
			lastMove = new Vector2 (horizontal, 0f);
		}
		if (vertical != 0f) {
			//transform.Translate (new Vector3(0f, vertical * movementSpeed * Time.deltaTime, 0f));

			charRigBody.velocity = new Vector2(charRigBody.velocity.x, vertical * movementSpeed);

			charMoving = true;
			lastMove = new Vector2 (0f, vertical);
		}

		if (horizontal == 0f) {
			charRigBody.velocity = new Vector2 (0f, charRigBody.velocity.y);
		} 
		if (vertical == 0f) {
			charRigBody.velocity = new Vector2 (charRigBody.velocity.x, 0f);
		}

		charAnimator.SetFloat("MoveX", horizontal);
		charAnimator.SetFloat("MoveY", vertical);
		charAnimator.SetBool("PlayerMoving", charMoving);
		charAnimator.SetFloat("LastMoveX", lastMove.x);
		charAnimator.SetFloat("LastMoveY", lastMove.y);
	}

	void HandleAttack() {
		if (Input.GetKeyDown(KeyCode.J)) {
			charAttacking = true;
			attackingTimeCounter = attackingTime;
			charRigBody.velocity = Vector2.zero;
			charAnimator.SetBool("PlayerAttacking", true);
		}
	}

	void HandleAttackCounter() {
		if (attackingTimeCounter > 0) {
			attackingTimeCounter -= Time.deltaTime;
		} else {
			charAttacking = false;
			charAnimator.SetBool ("PlayerAttacking", false);
		}
	}

	void ResetValues() {
		charMoving = false;
	}
}
