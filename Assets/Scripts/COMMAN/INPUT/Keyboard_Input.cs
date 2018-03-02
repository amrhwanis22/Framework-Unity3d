using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Comman/Keyboard Input Controller")]
public class Keyboard_Input : BaseInputController {


	public override void CheckInput()
	{
		Vert = Input.GetAxis ("Vertical");
		Horiz = Input.GetAxis ("Horizontal");


		Up = (Vert > 0);
		Down = (Vert < 0);
		Left = (Horiz > 0);
		Right = (Horiz < 0);

		Fire = Input.GetButton ("Fire1");
		ShouldRespwan = Input.GetButton ("Fire3");

	}
	public void LateUpdate()
	{
		CheckInput ();
	}
}
