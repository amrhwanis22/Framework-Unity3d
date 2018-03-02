using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour {

	public GameObject ObjectToSpawnOnTrigger;
	public Vector3 offsetPosition;
	public bool OnlySpawnOnce;
	public int layerToCauseTriggerHit=13;

	private Transform myTransform;

	// Use this for initialization
	void Start () {
	
		Vector3 tempPos = transform.position;
		tempPos.y = Camera.main.transform.position.y;
		myTransform = transform;
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer!=layerToCauseTriggerHit)
		{
			return;
			
		}
		Instantiate (ObjectToSpawnOnTrigger, myTransform.position + offsetPosition, Quaternion.identity);
		if (OnlySpawnOnce) {

			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
