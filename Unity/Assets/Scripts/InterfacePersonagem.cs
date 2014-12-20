using UnityEngine;
using System.Collections;

public class InterfacePersonagem : MonoBehaviour {

	private MovimentacaoPersonagem _movimetacaoPersonagem;
	// Use this for initialization
	void Start () {
		_movimetacaoPersonagem = GetComponent<MovimentacaoPersonagem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoLeft() {
		_movimetacaoPersonagem.GoLeft();	
	}	
}
