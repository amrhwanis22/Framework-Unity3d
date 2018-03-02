using UnityEngine;
using System.Collections;

public class BaseInputController : MonoBehaviour
{

	public bool Up;
	public bool Down;
	public bool Left;
	public bool Right;


	public bool Fire;

	public bool Slot1,Slot2,Slot3,Slot4,Slot5,Slot6,Slot7,Slot8,Slot9,Slot10;
	public float Vert;
	public float Horiz;
	public bool ShouldRespwan;
	public Vector3 TempVec3;
	private Vector3 zeroVector = new Vector3 (0,0,0);
	public virtual void CheckInput()
	{
		Horiz = Input.GetAxis ("Horizontal");
		Vert = Input.GetAxis ("Vertical");
	}
	public virtual float GetHorizontal()
	{
		return Horiz;
	}
	public virtual float GetVertical()
	{
		return Vert;
	}
	public virtual bool GetFired()
	{
		return Fire;
	}
	public bool GetRespwan()
	{
		return ShouldRespwan;
	}
	public virtual Vector3 GetMovementDirectionVector()
	{
		TempVec3 = zeroVector;
		if (Left || Right) {
		
			TempVec3.x = Horiz;
		
		}
		if (Up || Down) {
		
			TempVec3.y = Vert;
		
		}
		return TempVec3;
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

