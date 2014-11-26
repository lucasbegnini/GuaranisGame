using UnityEngine;
using System.Collections;

public class Movimentacao : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow))
			rigidbody2D.AddForce(-50*Vector2.right);
		else if(Input.GetKey(KeyCode.RightArrow))
			rigidbody2D.AddForce(50*Vector2.right);
		if(Input.GetKey(KeyCode.Space))
			rigidbody2D.AddForce(50*Vector2.up);
	}
}
