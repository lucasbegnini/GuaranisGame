using UnityEngine;
using System.Collections;

public class ControleCarapana : MonoBehaviour {

	private Vector2 _minTela;
	private Vector2 _maxTela;
	private Vector2 _novaPosicao;
	public float speed;
	private Animator anim;
	private Collider2D triggerColisor;
	private Score setScore;
	// Use this for initialization
	void Start () {
		setScore = GameObject.FindGameObjectWithTag ("score").GetComponent<Score> ();
		anim = GetComponent<Animator> ();
		triggerColisor = GetComponent<Collider2D>();
		triggerColisor.enabled = true;
		_minTela = new Vector2(-11f,-12f);
		_maxTela = new Vector2(11f,1f);
		speed = 3f;
		Invoke("NovaPosicao",speed);
		_novaPosicao = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position,_novaPosicao, Time.deltaTime * speed);
	}
	
	void NovaPosicao(){
		float aleatorioX = Random.Range(_minTela.x,_maxTela.x);
		float aleatorioY = Random.Range(_minTela.y,_maxTela.y);
		_novaPosicao = new Vector2(aleatorioX,aleatorioY);
		Invoke("NovaPosicao",Random.Range(1f,speed));
	}

	void OnTriggerEnter2D(Collider2D c){
//		Debug.Log (c.gameObject.name);
		if(c.gameObject.CompareTag("dardo")){
			Destroy(c.gameObject);
			anim.SetBool("morrendo", true);
			triggerColisor.enabled = false;
			Invoke("Kill", 0.8f);

		}
	}

	void Kill(){
		transform.parent.SendMessage("CriaCarapana");
		Destroy(gameObject);
	}
}
