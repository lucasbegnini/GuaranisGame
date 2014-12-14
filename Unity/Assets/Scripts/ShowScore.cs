using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {
	private Score score;
	void OnGUI()
	{
		score = GameObject.FindGameObjectWithTag ("score").GetComponent<Score> ();
		GetComponent<Text> ().text = score.getScore ().ToString ();
	}
}
