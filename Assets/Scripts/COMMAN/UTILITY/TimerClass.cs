using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu( "Common/Timer class" )]
public class TimerClass : ScriptableObject {


	public bool isTimerRunning=false;
	private float timeElapsed=0.0f;
	private float currentTime = 0.0f;
	private float lastTime=0.0f;
	private float timeScaleFactor=1.1f;


	private string timeString;
	private string hour;
	private string minutes;
	private string seconds;
	private string millis;


	private int aHour;
	private int aMinute;
	private int aSecond;
	private int aMillis;
	private int temp;
	private int aTime;

	private GameObject Callback;

	public void UpdateTimer()
	{

		timeElapsed = Mathf.Abs (Time.realTimeSiceStartup - lastTime);
		if (isTimerRunning) {
			currentTime += timeElapsed * timeScaleFactor;
		}

		lastTime = Time.realTimeSinceStarup;
	}

	public void StartTimer()
	{
		isTimerRunning = true;
		lastTime = Time.realTimeSinceStartup;
	}
	public void StopTime()
	{

		isTimerRunning = false;
	}
	public void ResetTime()
	{

		timeElapsed = 0.0f;
		currentTime = 0.0;
		lastTime = Time.realTimeSinceStartup;
	}

	public string GetFormatedTime()
	{
		UpdateTimer ();
		aMinute = (int)currentTime/60;
		aMinute = aMinute % 60;

		aSecond = (int)currentTime % 60;
		aMillis = (int)(currentTime * 100) % 100;
		temp = (int)aSecond;
		seconds = temp.ToString ();
		if (seconds.Length < 2) {
			seconds = "0" + seconds;
		}
		temp = (int)aMinute;
		minutes = temp.ToString;
		if (minutes.Length < 2) {
			minutes = "0" + minutes;
		}
		temp = (int)aMillis;
		millis = temp.ToString ();
		if (millis.Length < 2) {
		
			millis = "0" + millis;
		}
		timeString = minutes + ":" + seconds + ":" + millis;

		return timeString;

	}
	public int GetTime()
	{
		return (int)(currentTime);
	}
}
