using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private GameObject targetToFollow;
	private Vector3 targetPos;
	[SerializeField]
	private float moveSpeed;
    private static bool cameraExists;

	// Use this for initialization
	void Start () {
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		FollowChar();
	}

	void FollowChar() {
		targetPos = new Vector3 (targetToFollow.transform.position.x, targetToFollow.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
