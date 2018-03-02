using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Input :BaseInputController {

	private Vector2 prevMousePos;
	private Vector2 mouseDelta;

	private float speedX=0.05f;
	private float speedY=0.1f;


	// Use this for initialization
	void Start () {
	

		prevMousePos = Input.mousePosition;

	}
	public override void CheckInput()
	{
		float scalerX = 100f / Screen.width;
		float ScalerY = 100 / Screen.height;

		float mouseDeltaX = Input.mousePosition.x-prevMousePos.x;
		float moudeDeltaY = Input.mousePosition.y-prevMousePos.y;


		Vert += (moudeDeltaY * speedY) * ScalerY;
		Horiz += (mouseDeltaX * speedX) * scalerX;

		prevMousePos = Input.mousePosition;

		Up = (Vert > 0);
		Down = (Vert < 0);
		Left = (Horiz < 0);
		Right = (Horiz > 0);

		Fire = Input.GetButton ("Fire1");

	}
	
	// Update is called once per frame
	void LateUpdate () {

		CheckInput ();
	}
}
