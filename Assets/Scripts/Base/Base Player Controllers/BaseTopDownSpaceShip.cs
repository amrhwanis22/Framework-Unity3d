using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTopDownSpaceShip : ExtendedCustomMonoBehavior {

	private Quaternion targerQuanterion;

	private float thePos;
	private float moveXAmount;
	private float moveZAmount;
	public float speedX=40f;
	public float speedZ=15f;

	public float limiX=15f;
	public float limitZ=15f;
	private float originZ;

	[System.NonSerialized]
	public Keyboard_Input default_Input;

	public float horizontal_input;
	public float vertical_input;


	// Use this for initialization
	public virtual void  Start () {

		didInit = false;
		this.Init ();
	}

	public virtual void Init()
	{

		myTransform = transform;
		myGameObject = gameObject;
		myRigrdBody = rigidbody;

		default_Input = myGameObject.AddComponent<Keyboard_Input> ();

		originZ = myTransform.localPosition.z;

		didInit = true;


	}

	public virtual void GameStart()
	{

		canControl = true;
	}
	public virtual void GetInput()
	{

		horizontal_input = default_Input.GetHorizontal ();
		vertical_input = default_Input.GetVertical ();

	}
	// Update is called once per frame
	public virtual void Update () {

		UpdateShip ();

	}

	public virtual void UpdateShip()
	{


		if (!didInit)
			return;

		if (!canControl)
			return;

		GetInput ();

		moveXAmount = horizontal_input * Time.deltaTime *speedX;
		moveZAmount = vertical_input * Time.deltaTime * speedZ;

		Vector3 tempRotation = myTransform.eulerAngles;
		tempRotation.z = horizontal_input * -30f;
		myTransform.eulerAngles = tempRotation;
		myTransform.localPosition += new Vector3 (moveXAmount, 0, moveZAmount);



		if (myTransform.localPosition.x <= -limiX || myTransform.localPosition.x >= limitZ) {
		
			thePos = Mathf.Clamp (myTransform.localPosition.x, -limiX, limiX);

			myTransform.localPosition = new Vector3 (thePos,myTransform.localPosition.y,myTransform.localPosition.z);


		}
		if (myTransform.localPosition.z <= -limitZ || myTransform.localPosition.z >= limitZ) {
		
		
			thePos = Mathf.Clamp (myTransform.localPosition.z, -limitZ, limitZ);
			myTransform.localPosition = new Vector3 (myTransform.localPosition.x, myTransform.localPosition.y, thePos);
		}

	}

}
