using UnityEngine;
using System.Collections;

public class OneWayCollider : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c){
		Debug.Log("OFF");
		if(c.collider is BoxCollider2D){
			collider2D.isTrigger = true;
		}
	}
	void OnTriggerEnter2D(Collider2D c){
		Debug.Log("ON");
		if(!(c is BoxCollider2D)){
			collider2D.isTrigger = false;
		}
	}
}
