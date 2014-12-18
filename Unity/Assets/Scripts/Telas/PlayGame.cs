using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {


	private Animator animador;
	// Use this for initialization
	void Start () {
		animador = GetComponent<Animator> ();
	}
	void OnMouseDown()
	{
		animador.SetTrigger("PlayPressionado");
		Invoke ("LoadTela", 0.8f);


	}
	void Escape()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
						Application.Quit ();
		
	}

	void LoadTela()
	{
		PlayerPrefs.SetInt ("multiplayer", 1);
		Application.LoadLevel ("SelecaoPersonagem");
	}
	// Update is called once per frame
	void Update () {
		Escape();
	}
}
