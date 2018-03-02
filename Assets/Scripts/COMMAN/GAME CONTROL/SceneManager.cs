using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {


	public string []LevelNames;
	public int GameLevelNum;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);

		
	}
	public void LoadLevel(string SceneName){
	
		Application.LoadLevel (SceneName);

	}

	public void GoNextLevel(){
	
		if (GameLevelNum >= LevelNames.Length) {
		
			GameLevelNum = 0;
		}
		LoadLevel (GameLevelNum);
		GameLevelNum++;

	}

	private void LoadLevel(int LevelNum)
	{

		LoadLevel (LevelNames [LevelNum]);

	}

	public void ResetGame()
	{
		GameLevelNum = 0;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
