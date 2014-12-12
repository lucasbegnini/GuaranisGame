using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private int score;
	
	public int getScore()
	{
		return score;
	}
	
	public void setScore()
	{
		score++;
	}
	
	public void SaveScore()
	{
		PlayerPrefs.SetInt ("Score", score);
		if (PlayerPrefs.GetInt ("BestScore") < score)
		{
			PlayerPrefs.SetInt ("BestScore", score);
		}
	}
	
	
	// Use this for initialization
	void Start () {
		
		score = 0;
	}

}
