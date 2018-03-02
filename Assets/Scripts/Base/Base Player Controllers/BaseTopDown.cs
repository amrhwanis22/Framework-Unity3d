using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTopDown : ExtendedCustomMonoBehavior {

	// @script RequireComponent(CharacterController)
	public AnimationClip idleAinmation;
	public AnimationClip walkingAnimation;
	public float walkMaxAnimationSpeed=.075f;
	public float runMaxAnimationSpeed = 1.0f;

	private float walkTimeStart=0.0f;

	public Animation _animation;

	enum CharacterState{
		Idle=0,
		Walking=1,
		Running=2,

	}
	private CharacterState _characterState;
	public float walkingSpeed=2.0f;

	public float runSpeed=4.0f;

	public float speedSmoothing=10.0f;
	public float rotateSpeed=500.0f;
	public float runAfterSeconds=3.0f;


	private Vector3 moveDirection=Vector3.zero;

	private float verticalSpeed=0.0f;

	public float moveSpeed=0.0f;

	private CollisionFlags  collisionFlags;
	public BasePlayerManager myPlayerController;
	[System.NonSerialized]
	public Keyboard_Input default_input;
	public float horz;
	public float vert;

	private CharacterController controller;

	void Awake()
	{

		moveDirection = transform.TransformDirection (Vector3.forward);

		if (_animation == null) {
			_animation = GetComponent<Animation> ();
		}
		if (!_animation) {
			Debug.Log ("the character you would like to control dosent have animations");
		}
		if (!idleAinmation)
		{
			_animation=null;
			Debug.Log ("No Idle Satate Anmation found shuttung down animations");
		}	
		if (!walkingAnimation) {
			_animation=null;
			Debug.Log ("No walking animation is found");
		}
		controller = GetComponent<CharacterController> ();



	}

	// Use this for initialization
	public virtual void  Start () {

		Init ();
	}
	public virtual void Init()
	{
		myRigrdBody = rigidbody;
		myTransform = transform;
		myGameObject = gameObject;


		default_input = myGameObject.AddComponent<Keyboard_Input> ();



		myPlayerController = myGameObject.GetComponent<BasePlayerManager> ();

		if (myPlayerController != null) {
			myPlayerController.Init ();
		}

	}
	public void SetUserInput(bool setInput)
	{
		canControl = setInput;
	}

	public virtual void GetInput()
	{
		horz = Mathf.Clamp (default_input.GetHorizontal(),-1,1);
		vert = Mathf.Clamp (default_input.GetVertical(), -1, 1);

	}
	
	// Update is called once per frame
	public virtual void LateUpdate () {
		if (canControl) {
			GetInput();
		}

	}
	public bool moveDirectionally;
	private Vector3 targetDirction;
	private float curSmooth;
	private float targetSpeed;
	private float curSpeed;
	private Vector3 forward;
	private Vector3 right;

	void UpdateSmoothedMovementDirection()
	{
		if (moveDirectionally) {
	
			UpdateDirctionalMovement ();
		} else {
		
			UpdateRotationMovement ();
		}
	}

	void UpdateDirctionalMovement(){

		targetDirction = horz * Vector3.right;

		targetDirction += vert * Vector3.forward;

		if (targetDirction != Vector3.zero) {
		
			moveDirection = Vector3.RotateTowards (moveDirection, targetDirction, rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);

			moveDirection = moveDirection.normalized;
		}
		curSmooth = speedSmoothing * Time.deltaTime;

		targetSpeed = Mathf.Min (targetDirction.magnitude, 1.0f);
		_characterState = _characterState.Idle;
		
		if (Time.time - runAfterSeconds > walkTimeStart) {
		
			targetSpeed *= runSpeed;
			_characterState = _characterState.Running;

		} else {
		
			targetSpeed *= walkingSpeed;
			_characterState = _characterState.Walking;
		}
		moveSpeed = Mathf.Lerp (moveSpeed, targetSpeed, curSmooth);
		if (moveSpeed < walkingSpeed * 0.3f) {
		
			walkingSpeed = Time.time;
		}
		Vector3 movement = moveDirection * moveSpeed;

		collisionFlags = controller.Move (movement);

		myTransform.rotation = Quaternion.LookRotation (moveDirection);

	}

	void UpdateRotationMovement()
	{

		myTransform.Rotate (0, horz * rotateSpeed * Time.deltaTime, 0);
		curSpeed = moveSpeed * vert;

		controller.SimpleMove (myTransform.forward * curSpeed);

		targetDirction = vert * myTransform.forward;





		float curSmooth = speedSmoothing * Time.deltaTime;

		targetSpeed = Mathf.Min (targetDirction.magnitude,1.0f);

		_characterState = _characterState.Idle;

		if (Time.time - runAfterSeconds > walkTimeStart) {
		
			targetSpeed *= runSpeed;
			_characterState = _characterState.Running;
		} else {
		
			targetSpeed *= walkingSpeed;
			_characterState = _characterState.Walking;
		}
		moveSpeed = Mathf.Lerp (moveSpeed,targetSpeed,curSmooth);
		if (moveSpeed < walkingSpeed * 0.3f) {
		
			walkTimeStart = Time.time;
		}
	}

	void Update()
	{

		if (!canControl) {
			Input.ResetInputAxes ();
		}
		UpdateSmoothedMovementDirection();

		if (_animation) {
		
			if (controller.velocity.sqrMagnitude < 0.1) {
			
				_animation.CrossFade (idleAinmation.name);
			} else {
			
				if (_characterState == CharacterState.Running) {
				
					_animation [walkingAnimation.name].speed = Mathf.Clamp (controller.velocity.magnitude, 0.0f, runMaxAnimationSpeed);
					_animation.CrossFade (walkingAnimation.name);

				} else if (_characterState == _characterState.Walking) {
				
					_animation [walkingAnimation.name].speed = Mathf.Clamp (controller.velocity.magnitude,0.0f,walkMaxAnimationSpeed);

					_animation.CrossFade (walkingAnimation.name);
				}
			}
		}
	}

	public float GetSpeed()
	{
		return moveSpeed;

	}
	public Vector3 GetDiriction()
	{
		return moveDirection;
	}
	public bool IsMoving()
	{
		return 	Mathf.Abs (vert) + Mathf.Abs (horz) > 0.5f;

	}
	public void Reset()
	{
		gameObject.tag="Player";
	}
}
