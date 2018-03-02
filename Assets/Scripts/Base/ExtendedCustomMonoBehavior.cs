using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedCustomMonoBehavior : MonoBehaviour {



	public Transform myTransform;
	public GameObject myGameObject;
	public Rigidbody myRigrdBody;

	public bool didInit;
	public bool canControl;
	public int id;

	[System.NonSerialized]
	public Vector3 myVector;

	[System.NonSerialized]
	public Transform tempTR;

	public void SetID(int ID)
	{

		id=ID;

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
