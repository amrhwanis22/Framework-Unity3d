using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGravity : MonoBehaviour {


	public Vector3 gravityScale=new Vector3(0,-12,81f,0);
	// Use this for initialization
	void Start () {
		Physics.gravity = gravityScale;
		this.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
