using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	private int Vida;
	// Use this for initialization
	void Start () {
		Vida = 3; 
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void CheckLife()
	{
		if (Vida <= 0) {
			Die();		
		}
	}

	void Die()
	{
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D other)
	{	

		if (other.collider.tag == "dardo" && other.transform.parent == transform){
			//Tira o life
			Vida--;		
			// Destroi o Dardo
			Destroy(other.gameObject);
			CheckLife ();
		}
	}
}
