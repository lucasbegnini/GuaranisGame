using UnityEngine;
using System.Collections;

public class ReplayGame : MonoBehaviour {


	void OnMouseDown()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
