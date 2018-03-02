using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : BaseTopDownSpaceShip {


	public BasePlayerManager myPlayerData;
	public BaseUserManager myDataManager;


	// Use this for initialization
	public override void Start () {
	
		base.Init ();
		this.Init ();

	}

	public override void Init()
	{
		if (myPlayerData == null) {
		
		
			myPlayerData = myGameObject.GetComponent<BasePlayerManager> ();
		}

		myDataManager = myPlayerData.DataManager;

		myDataManager.SetName ("Amroo");
		myDataManager.SetHealth (150);
		didInit = true;
	}
	
	// Update is called once per frame
	public override void Update () {

		UpdateShip ();

		if (!didInit) {
			return;
		}
		if (!canControl) {
		
			return;
		}


	}
	public override void GetInput()
	{
		horizontal_input = default_Input.GetHorizontal ();
		vertical_input = default_Input.GetVertical ();
	}
	void OnCollisionEnter(Collision colider)
	{


	}
	void OnTriggerEnter(Collider other)
	{
		
	}
	void PlayerFinisher()
	{


	}
	public void ScoredPoints(int howMany){

		myDataManager.AddScore (howMany);
	}




}
