using UnityEngine;
using System.Collections;

public class Colisao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c) {
		Debug.Log("Hello");
		if(c.gameObject.CompareTag("OneWayPlatform") && transform.position.y > c.transform.position.y)
			Physics2D.IgnoreCollision(this.collider2D, c.collider, true);
		else
			Physics2D.IgnoreCollision(this.collider2D, c.collider, false);
	}
}
