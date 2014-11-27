using UnityEngine;
using System.Collections;

public class Movimentacao : MonoBehaviour {


	public int velocidade;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow))
			GoLeft();
		else if(Input.GetKey(KeyCode.RightArrow))
			GoRight();
		if(Input.GetKey(KeyCode.Space))
			Jump();
	}

	void GoLeft() {
		rigidbody2D.AddForce(-velocidade*Vector2.right*Time.deltaTime);
	}

	void GoRight() {
		rigidbody2D.AddForce(velocidade*Vector2.right*Time.deltaTime);
	}

	void Jump() {
		rigidbody2D.AddForce(velocidade*Vector2.up*Time.deltaTime);
	}
}
