using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {
	
	public GameObject missile;
	private GameObject _missile;
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
		if(Input.GetKeyDown(KeyCode.K))
			Atirar();
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

	void Atirar(){
		_missile = GameObject.Instantiate(missile) as GameObject;
		_missile.transform.parent = transform;
		_missile.SendMessage("Starting",true);
	}

}
