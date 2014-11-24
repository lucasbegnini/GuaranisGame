using UnityEngine;
using System.Collections;

public class BestScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		GetComponent<TextMesh> ().text = PlayerPrefs.GetInt("highscore").ToString();
	}
}
