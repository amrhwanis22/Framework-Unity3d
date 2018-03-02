using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseVehicle : ExtendedCustomMonoBehavior {


	public WheelCollider frontWheelLeft;
	public WheelCollider frontWheelRight;
	public WheelCollider rearWheelLeft;
	public WheelCollider rearWheelRight;

	public float steerMax = 30.0f;
	public float accMax = 5000f;
	public float brakeMax = 5000f;
	public float steer=0f;
	public float motor = 0f;
	public float brake = 0f;
	public float mySpeed;
	public bool isLocked;
	[System.NonSerialized]
	public Vector3 velo;

	[System.NonSerialized]
	public Vector3 flatVelo;

	public BasePlayerManager myPlayerController;
	[System.NonSerialized]
	public Keyboard_Input default_input;

	public AudioSource engineSound;

	
	// Use this for initialization
	public virtual void Start () {
		Init();
	}
	public virtual void Init()
	{


		myRigrdBody = rigidbody;
		myGameObject = gameObject;
		myTransform = transform;

		default_input = myGameObject.AddComponent<Keyboard_Input>();
		myPlayerController = myGameObject.GetComponent<BasePlayerManager>();

		myPlayerController.Init();


		myRigrdBody.centerOfMass = new Vector3(0, -4f, 0);

		if (engineSound == null)
		{

			engineSound = myGameObject.GetComponent<AudioSource>();
		}



	}
	public void SetUserInput(bool SetInput)
	{
		canControl = SetInput;
	}
	public void SetLock(bool Lock)
	{
		isLocked = Lock;

	}
	public virtual void LateUpdate()
	{

		if (canControl)
		{
			GetInput();
		}
		UpdateEngineAudio();
	}
	public virtual void FixedUpdate()
	{
		UpdatePhysics();
	}
	public virtual void UpdateEngineAudio()
	{

		engineSound.pitch = 0.5f + (Mathf.Abs(mySpeed) * 0.005f);


	}
	public virtual void UpdatePhysics()
	{

		CheckLock();
		velo = myRigrdBody.angularVelocity;
		velo = transform.InverseTransformDirection(myRigrdBody.velocity);
		flatVelo.x = velo.x;
		flatVelo.y = 0;
		flatVelo.z = velo.z;
		mySpeed = velo.z;
		if(mySpeed<2)
		{
			if(brake>0)
			{
				rearWheelLeft.motorTorque = -brakeMax * brake;
				rearWheelRight.motorTorque = -brakeMax * brake;
				rearWheelRight.brakeTorque = 0;
				rearWheelLeft.brakeTorque = 0;
				frontWheelRight.steerAngle = steerMax * steer;
				frontWheelLeft.steerAngle = steerMax * steer;
				return;
			}
		}

		rearWheelRight.motorTorque = accMax * motor;
		rearWheelLeft.motorTorque = accMax * motor;
		rearWheelLeft.brakeTorque = brakeMax * brake;
		rearWheelRight.brakeTorque = brakeMax * brake;
		frontWheelLeft.steerAngle = steerMax * steer;
		frontWheelRight.steerAngle = steerMax * steer;

	}

	public void CheckLock()
	{

		if(isLocked)
		{
			steer = 0;
			motor = 0;
			brake = 0;
			Vector3 tempVec = myRigrdBody.velocity;
			tempVec.x = 0;
			tempVec.z = 0;
			myRigrdBody.velocity = tempVec;
		}
	}
	public virtual void GetInput()
	{
		steer = Mathf.Clamp(default_input.GetHorizontal(), -1, 1);
		motor = Mathf.Clamp(default_input.GetVertical(), 0, 1);
		brake = -1 * Mathf.Clamp(default_input.GetVertical(), -1, 0);


	}
	// Update is called once per frame
	void Update () {
		
	}
}
