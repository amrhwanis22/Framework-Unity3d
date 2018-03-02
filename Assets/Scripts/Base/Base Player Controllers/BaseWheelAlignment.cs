using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWheelAlignment : MonoBehaviour {


	public WheelCollider CorrospoindingCollider;
	public GameObject slipPrefab;
	public float slipAmountForTireSmoke = 50f;
	private float RotationValue = 0.0f;	private Transform myTransform;
	private Quaternion zeroRotation;
	private Transform colliderTransfrom;
	private float suspensionDistance;


	// Use this for initialization
	void Start () {
		myTransform = transform;
		zeroRotation = Quaternion.identity;
		colliderTransfrom = CorrospoindingCollider.transform;

	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Vector3 ColliderCenterPoint = colliderTransfrom.TransformPoint(CorrospoindingCollider.center);


		if (Physics.Raycast(ColliderCenterPoint, -colliderTransfrom.up, out hit, CorrospoindingCollider.suspensionDistance + CorrospoindingCollider.radius))
		{
			myTransform.position = hit.point + (colliderTransfrom.up * CorrospoindingCollider.radius);


		}
		else {

			myTransform.position = ColliderCenterPoint - (colliderTransfrom.up * CorrospoindingCollider.suspensionDistance);

		}
		myTransform.rotation = colliderTransfrom.rotation * Quaternion.Euler(RotationValue,CorrospoindingCollider.steerAngle,0);

		RotationValue += CorrospoindingCollider.rpm * (360 / 60) * Time.deltaTime;
		WheelHit correspondingGroundHit = new WheelHit();
		CorrospoindingCollider.GetGroundHit(out correspondingGroundHit);
		if (Mathf.Abs(correspondingGroundHit.sidewaysSlip) > slipAmountForTireSmoke)
		{
			if (slipPrefab)
			{
				SpwanController.Instance.Spawn(slipPrefab, correspondingGroundHit.point, zeroRotation);
			}
		}
	}
}
