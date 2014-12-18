using UnityEngine;
using System.Collections;

public class ImagemHUD : MonoBehaviour {
	public Sprite Uirapuru;
	public Sprite Guarana;
	private Sprite escolha;
	// Use this for initialization
	void Start () {

		getPersonagem ();
		//escolha = Guarana;
			GetComponent<SpriteRenderer> ().sprite = escolha;
	
	}

	void getPersonagem()
	{
		if (PlayerPrefs.GetInt ("escolha") == 1)
			escolha = Uirapuru;
		if (PlayerPrefs.GetInt ("escolha") == 2)
			escolha = Guarana;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
