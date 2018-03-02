using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanController : ScriptableObject {
	private ArrayList playerTransform;
	private ArrayList playerGameObject;
	private Transform tempTrans;
	private GameObject tempGO;

	private GameObject[] playerPrefabList;
	private Vector3[] startPositions;
	private Quaternion[] startRotations;
	private static SpwanController instance;
	public SpwanController(){
	
		if (instance != null) {
			Debug.LogWarning ("Tried to generate more than one instance of singleton SpwanController");
			return;
		}
		instance = this;
	}
	public static SpwanController Instance{

		get{ 
			if (instance == null) {

				ScriptableObject.CreateInstance<SpwanController> ();//new SpwanContrroler();
			}	
			return instance;

			}
	}
	public void Restart()
	{

		playerTransform = new ArrayList ();
		playerGameObject = new ArrayList ();


	}
	public void SetUpPlayers(GameObject [] playerPrefabs,Vector3[] PlayerPositions,Quaternion[] playerstartRotation,Transform theParentObject,int totalPlayers)
	{


		playerPrefabList = playerPrefabs;
		startPositions = PlayerPositions;
		startRotations = playerstartRotation;

		CreatePlayers (theParentObject, totalPlayers);

	}
	public void CreatePlayers(Transform parent,int totalPlayers)
	{

		playerTransform = new ArrayList ();
		playerGameObject = new ArrayList ();

		for (int i = 0; i < totalPlayers; i++) {
		
			tempTrans = Spawn (playerPrefabList [i], startPositions [i], startRotations [i]);
			if (parent != null) {
			
				tempTrans.parent = parent;
				tempTrans.localPosition = startPositions [i];

			}
			playerTransform.Add (tempTrans);

			playerGameObject.Add (tempTrans.gameObject);

		
		}
		
	}
	public GameObject GetPlayerGO(int Index)
	{
		return (GameObject)playerGameObject [Index];
	}
	public Transform GetPlayerTransform(int Index)
	{

		return (Transform)playerTransform [Index];
	}
	public Transform Spawn(GameObject player,Vector3 aPosition,Quaternion aRotation)
	{



		tempGO = (GameObject)Instantiate (player, aPosition, aRotation);
		tempTrans = tempGO.transform;
		return tempTrans;


	}
	public GameObject SpawnGO(GameObject player,Vector3 aPosition,Quaternion Rotation)
	{


		tempGO = (GameObject)Instantiate (player, aPosition, Rotation);
		tempTrans = tempGO.transform;
		return tempGO;

	}
	public ArrayList GetAllSpawnedPlayers()
	{
		return playerTransform;
	}



}
