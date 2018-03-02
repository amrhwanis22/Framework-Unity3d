using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Base/Camera Controller")]
public class BaseCameraController : MonoBehaviour {

	public Transform cameraTargert;
	public virtual void SetTarget(Transform aTarget)
	{

		cameraTargert = aTarget;

	}

}
