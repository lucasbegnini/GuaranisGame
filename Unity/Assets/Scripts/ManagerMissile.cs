using UnityEngine;
using System.Collections;

public class ManagerMissile : MonoBehaviour {
	
	public float speed;
	public bool facedRight;
	// Use this for initialization
	void Start () {
		Vector3 playerCenter = transform.parent.transform.position;
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
		transform.parent = null;

	}
	
	// Update is called once per frame
	void Update () {
	}

	void Starting(){
		Vector3 playerCenter = transform.parent.transform.position;
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
		transform.parent = null;
	}

	void Kill(){
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D target){
			Kill();
	}
}
