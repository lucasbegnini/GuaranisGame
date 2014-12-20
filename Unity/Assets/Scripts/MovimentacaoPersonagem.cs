using UnityEngine;
using System.Collections;

public class MovimentacaoPersonagem : MonoBehaviour {

	private int _velocidade;
	private bool _isfacedRight;
	private bool _onFloor;
	private Animator _anim;
	public bool pulo;
	// Use this for initialization
	void Start () {
		_isfacedRight = true;
		_onFloor = true;
		pulo=false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoLeft() {
		Vector3 aux = transform.localScale;
		Vector2 aux1 = rigidbody2D.velocity;
		aux1.x = -_velocidade*Vector2.right.x;
		rigidbody2D.velocity = aux1;
		aux.x=1;
		transform.localScale = aux;
		_isfacedRight = false;
	}
	
	public	void GoRight() {
		Vector3 aux = transform.localScale;
		Vector2 aux1 = rigidbody2D.velocity;
		aux1.x = _velocidade*Vector2.right.x;
		rigidbody2D.velocity = aux1;
		aux.x=-1;
		transform.localScale = aux;
		_isfacedRight = true;
	}
	
	public void Jump() {
		GameObject.FindGameObjectWithTag ("jump button").GetComponent<Animator> ().SetTrigger ("Pressionado");
		if(!pulo)
		{
			_onFloor = false;
			Vector2 aux = rigidbody2D.velocity;
			aux.y = 18*Vector2.up.y;
			rigidbody2D.velocity = aux;
			pulo = true;
		}
	}

}
