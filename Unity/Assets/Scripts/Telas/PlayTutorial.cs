using UnityEngine;
using System.Collections;

public class PlayTutorial : MonoBehaviour {

	private Animator animador;
	// Use this for initialization
	void Start () {
		animador = GetComponent<Animator> ();
	}
	void OnMouseDown()
	{
		animador.SetTrigger("Pressionado");
		Invoke ("LoadTela", 1f);
		
		
	}
	
	void LoadTela()
	{
		PlayerPrefs.SetInt ("multiplayer",0);
		Application.LoadLevel ("SelecaoPersonagem");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
