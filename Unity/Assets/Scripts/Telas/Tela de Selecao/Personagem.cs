using UnityEngine;
using System.Collections;

public class Personagem : MonoBehaviour {
	public Sprite Uirapuru;
	public Sprite Guarana;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		MostrarPersonagem ();
	
	}

	void MostrarPersonagem()
	{
		if (PlayerPrefs.GetInt ("escolha") == 1) {
			GetComponent<SpriteRenderer>().sprite = Uirapuru;		
		}
		if (PlayerPrefs.GetInt ("escolha") == 2) {
			GetComponent<SpriteRenderer>().sprite = Guarana;
				}
	}
}
