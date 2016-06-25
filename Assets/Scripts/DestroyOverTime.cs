﻿using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour {

	[SerializeField]
	private float timeToDestroy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeToDestroy -= Time.deltaTime;

		if (timeToDestroy <= 0) {
			Destroy (gameObject);
		}
	}
}
