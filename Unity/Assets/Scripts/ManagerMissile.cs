using UnityEngine;
using System.Collections;

public class ManagerMissile : MonoBehaviour {
	
	public float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	void Starting(bool facedRight){
		GameObject player = GameObject.FindWithTag("Player") as GameObject;
		Vector3 playerCenter = player.transform.position;
		if(facedRight){
			rigidbody2D.velocity = new Vector2(speed,0);
			Vector3 vect = transform.localScale;
			vect.x *= -1;
			transform.localScale = vect;
		}
		else{
			rigidbody2D.velocity = new Vector2(-speed,0);
		}
		transform.position = playerCenter;
	}

	void Kill(){
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D target){
			Kill();
	}
}
