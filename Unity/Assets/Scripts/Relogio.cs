using UnityEngine;
using System.Collections;
using System;

public class Relogio : MonoBehaviour {

	private float tempodeJogo;
	private AudioSource relogioSFX;
	// Use this for initialization

	void Start () {

		relogioSFX = GetComponent<AudioSource> ();
		//Tempo de jogos em segundos
		tempodeJogo = 30.0f;
		//relogioSFX.Play();
		//Inicia o jogo ja com tempo final para acabar
		Invoke ("gameOver", tempodeJogo);
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void gameOver()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

}
