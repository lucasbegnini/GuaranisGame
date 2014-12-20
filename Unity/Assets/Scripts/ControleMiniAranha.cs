using UnityEngine;
using System.Collections;

public class ControleMiniAranha : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("Kill",19);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D c){
		rigidbody2D.velocity = new Vector2(Random.Range(5,8),0);
		if(c.collider.CompareTag("floor")){
			int aux = Random.Range(0,2);
			if(aux == 1){
				Vector2 velocity = rigidbody2D.velocity;
				velocity.x *= -1;
				rigidbody2D.velocity = velocity;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D c){
		if(c.CompareTag("dardo")){
			Destroy(c.gameObject);
			Kill();
		}
	}

	void Kill(){
		int pontuacao = PlayerPrefs.GetInt("pontuacao");
		PlayerPrefs.SetInt("pontuacao",++pontuacao);
		Destroy(gameObject);
	}
	
}
