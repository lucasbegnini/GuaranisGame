using UnityEngine;
using System.Collections;

public class Trofeus : MonoBehaviour {

	private int trofeus;

	public int getTrofeus()
	{
		return trofeus;
	}
	
	public void setTrofeus()
	{
		trofeus++;
	}

	public void SaveTrofeus()
	{
		PlayerPrefs.SetInt ("trofeus", trofeus);
		if (PlayerPrefs.GetInt ("trofeus") >= 3)
		{
			PlayerPrefs.SetInt ("trofeus", 0);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
