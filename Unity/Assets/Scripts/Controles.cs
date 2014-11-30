using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {
	
	public int velocidade;
	public GameObject missile;
	private GameObject _missile;
	private Animator anim;
	private bool _isfacedRight;
	private AnimatorStateInfo info;
	private AnimationInfo[] teste;
	private bool pulo;
	// Use this for initialization
	void Start () {
		anim =  GetComponent<Animator>();
		pulo = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow))
			GoLeft();
		else if(Input.GetKey(KeyCode.RightArrow))
			GoRight();
		if(Input.GetKeyDown(KeyCode.Space))
			Jump();
		if(Input.GetKeyDown(KeyCode.K)){
			Atirar ();

		}
		if(!Input.anyKey){

			anim.SetTrigger("parado");
		}
	}

	void GoLeft() {
		Vector3 aux = transform.localScale;
		Vector2 aux1 = rigidbody2D.velocity;
		aux1.x = -velocidade*Vector2.right.x*Time.deltaTime;
		rigidbody2D.velocity = aux1;
		aux.x=1;
		transform.localScale = aux;
		_isfacedRight = false;
		anim.SetTrigger("correndo");

	}

	void GoRight() {
		Vector3 aux = transform.localScale;
		aux.x=-1;
		transform.localScale = aux;
		_isfacedRight = true;
		rigidbody2D.velocity = velocidade*Vector2.right*Time.deltaTime;
		anim.SetTrigger("correndo");
	}

	void Jump() {
		if(!pulo)
		{
			Vector2 aux = rigidbody2D.velocity;
			aux.y = 10*Vector2.up.y;
			rigidbody2D.velocity = aux;
			pulo = true;
		}
	}
	void Atirar(){
		anim.SetTrigger("atirando");
		_missile = GameObject.Instantiate(missile) as GameObject;
		_missile.transform.parent = gameObject.transform;
		_missile.GetComponent<ManagerMissile>().facedRight = _isfacedRight;
	}

	void OnCollisionStay2D(Collision2D hit)
	{
		if(hit.collider.tag == "floor")
		{
			pulo = false;
		}
	}

}
