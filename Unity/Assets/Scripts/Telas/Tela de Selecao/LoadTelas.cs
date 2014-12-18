using UnityEngine;
using System.Collections;

public class LoadTelas : MonoBehaviour {

	void OnMouseDown()
	{
		if (PlayerPrefs.GetInt ("multiplayer") == 0)
		{
			Application.LoadLevel ("Carapanã");
		}else {
			Application.LoadLevel("Mapa 1-1");
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
