using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Spawner : MonoBehaviour {


	public Waypoints_Controller waypointControl;

	public bool distanceBasedSpawnStart;
	public float distanceFromCameraToSpawnAt=35f;


	public bool shouldAutoRespawningOnLoad;

	public float timeBetweenSpawn=1;
	public int totalAmountToSpawn=10;
	public bool shouldReversePath;


	public GameObject [] spwanObjectPrefabs;

	private int totalSpawnObjects;

	private Transform myTransfrom;
	private GameObject tempObj;
	private int spawnCounter=0;


	private int currentObjectNum;
	private Transform cameraTransform;
	private bool spwaning;

	public bool shouldSetSpeed;
	public float speedToSet;

	public bool shouldSetSmoothing;
	public float smoothingToSet;

	public bool shouldSetRotateSpeed;
	public float rotateToSet;

	private bool didInit;







	// Use this for initialization
	void Start () {



		Init ();
	}

	void Init()
	{

		myTransfrom = transform;

		Camera mainCam = Camera.main;
		if (mainCam == null) {
		
		
			return;
		}
		cameraTransform = mainCam.transform;

		waypointControl.SetReverseMode (shouldReversePath);
		totalSpawnObjects = spwanObjectPrefabs.Length;

		if (shouldAutoRespawningOnLoad) {
		
			StartWave (totalAmountToSpawn, timeBetweenSpawn);
		
		}

	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color (0, 1, 0.5f);
		Gizmos.DrawCube (transform.position, new Vector3 (200, 0, distanceFromCameraToSpawnAt));

	}

	
	// Update is called once per frame
	void Update () {
	
		float aDist = Mathf.Abs (myTransfrom.position.z-cameraTransform.position.z);

		if (distanceBasedSpawnStart && !spwaning && aDist < distanceFromCameraToSpawnAt) {
			StartWave (totalAmountToSpawn, timeBetweenSpawn);
			spwaning = true;
		}

	}

	public void StartWave(int totalAmount,float timeBetweenSpawning)
	{
		spawnCounter=0;
		totalAmountToSpawn=totalAmount;
		currentObjectNum=0;
		CancelInvoke("doSpawn");
		InvokeRepeating("doSpawn",timeBetweenSpawn,timeBetweenSpawn);

	}
	void doSpawn()
	{

		SpawnObject ();
	}
	public void SpawnObject()
	{

		if (spawnCounter >= totalAmountToSpawn) {
		
		
			CancelInvoke ("doSpawn");
			this.enabled = false;
			return;
		}

		tempObj = SpwanController.Instance.SpawnGO (spwanObjectPrefabs [currentObjectNum], myTransfrom.position, Quaternion.identity);
		tempObj.SendMessage ("SetReversePath",shouldReversePath,SendMessageOptions.DontRequireReceiver);

		tempObj.SendMessage ("SetWayController", waypointControl, SendMessageOptions.DontRequireReceiver);

		if (shouldSetSpeed) {
		
			tempObj.SendMessage ("SetSpeed", speedToSet, SendMessageOptions.DontRequireReceiver);
		}
		if (shouldSetSmoothing) {
		
		
			tempObj.SendMessage ("SetPathSmoothingRate", smoothingToSet, SendMessageOptions.DontRequireReceiver);
		}
		if (shouldSetRotateSpeed) {
		
			tempObj.SendMessage ("SetRotateSpeed", rotateToSet, SendMessageOptions.DontRequireReceiver);

		}
		spawnCounter++;
		currentObjectNum++;
		if (currentObjectNum > totalSpawnObjects - 1) {
			currentObjectNum = 0;
		}


	}
}
