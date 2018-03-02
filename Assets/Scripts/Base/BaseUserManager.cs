using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Base/User Manager")]
public class BaseUserManager : MonoBehaviour {

	private int Score;
	private int HighScore;
	private int Level;
	private int Health;
	private bool isFinished;
	public string PlayerName="AMR";


	public virtual void GetDefaultData(){

		PlayerName = "AMR";
		Score = 0;
		Health = 100;
		HighScore = 0;
		isFinished = false;
	}
	public string GetName(){
		return this.PlayerName;
	}
	public void SetName(string name)
	{
		this.PlayerName = name;
	}

	public void SetLevel(int level)
	{
		this.Level = level;
	}
	public int GetLevel(){
		return this.Level;
	}
	public void SetHighScore(int Hscore)
	{
		this.HighScore = Hscore;

	}
	public int GetHighScore(){

		return this.HighScore;
	}
	public void SetHealth(int health){

		this.Health = health;
	}
	public int GetHealth(){
	
		return this.Health;
	}
	public void SetScore(int socre)
	{
		this.Score = socre;
	}
	public int GetScore()
	{
		return this.Score;
	}
	public virtual void AddScore(int value){

		this.Score += value;
	}
	public virtual void LostScore(int value)
	{
		this.Score -= value;

	}
	public virtual void AddHealth(int value)
	{
		this.Health += value;
	}
	public virtual void ReduceHealth(int value)
	{

		this.Health -= value;
	}
	public void SetIsFinished(bool finish)
	{
		this.isFinished = finish;
	}
	public bool GetIsFinished(){

		return this.isFinished;
	}



	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
