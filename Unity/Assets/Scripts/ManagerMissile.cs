using UnityEngine;
using System.Collections;

public class ManagerMissile : MonoBehaviour {
	
	public float speed;
	public bool facedRight;
	public int Pai;
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
		Pai = transform.parent.GetComponent<Life>().Retornaid();
		transform.parent = null;
		Invoke("Kill",3f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public int  Retornaid()
	{
		return PhotonNetwork.player.ID;
		
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

	void OnCollisionEnter2D(Collision2D c){
		if(!c.gameObject.CompareTag("Player"))
			Kill();
	}

	void Kill(){
		if(PhotonNetwork.connected)
		PhotonNetwork.Destroy (gameObject);
		else
		Destroy(gameObject);
	}
	
}
