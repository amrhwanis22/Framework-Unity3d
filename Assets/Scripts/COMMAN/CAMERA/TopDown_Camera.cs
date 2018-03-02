﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown_Camera : MonoBehaviour {

	public Transform followTarget;
	public Vector3 targetOffset;
	public float moveSpeed = 2.0f;

	private Transform myTransform;
	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	public void SetTarger(Transform aTransform)
	{
		followTarget = aTransform;
	}

	void LateUpdate()
	{
		if (followTarget != null) {
		
			myTransform.position = Vector3.Lerp (myTransform.position,followTarget.position+targetOffset,moveSpeed*Time.deltaTime);
		}
	}
}
