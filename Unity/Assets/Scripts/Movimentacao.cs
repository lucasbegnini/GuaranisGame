using UnityEngine;
using System.Collections;

public class Movimentacao : MonoBehaviour {


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
		rigidbody2D.AddForce(-50*Vector2.right);
	}

	void GoRight() {
		rigidbody2D.AddForce(50*Vector2.right);
	}

	void Jump() {
		rigidbody2D.AddForce(50*Vector2.up);
	}
}
