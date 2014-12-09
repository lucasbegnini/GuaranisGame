using UnityEngine;
using System.Collections;

public class ColisorPernasPersonagem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{

		if (c.gameObject.CompareTag("carapana")) {
					Physics2D.IgnoreCollision (c, collider2D, true);
			
		}
	}
}
