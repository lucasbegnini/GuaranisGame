using UnityEngine;
using System.Collections;

public class SelecionaPersonagem : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Seleciona(int selecao){
		PlayerPrefs.SetInt ("escolha", selecao);
	}
}
