 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Base/GameController")]
public class BaseGameContoller : MonoBehaviour {
	bool Pause;
	public GameObject explosionFab;
	public virtual void PlayerLostLife(){


	}
	public virtual void Respawn(){
	
		
	}
	public virtual void SpanPlayer(){
	
	}
	public virtual void StartGame(){
	}
	public virtual void Explode(Vector3 Position)
	{
		Instantiate (explosionFab, Position, Quaternion.identity);
	}
	public virtual void EnmeyDestroyed(Vector3 aPosition,int Points,int hitByID)
	{
		
	}
	public virtual void BossDestroyed()
	{
	}
	public void RestarGameButtonPressed(){
		Application.LoadLevel(Application.loadedLevelName);

	}

	public bool Paused{
		get{ 
			return Pause;
		}
		set{ 
		
			Pause = value;
			if (Pause) {
			
				Time.timeScale = 0f;
			} else {
				Time.timeScale = 1f;
			}
		
		}


	}

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
