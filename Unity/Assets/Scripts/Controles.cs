using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {

	static int deltaTime = 1;
	public int velocidade;
	public GameObject missile;
	private GameObject _missile;
	private Animator anim;
	private bool _isfacedRight;
	private AnimatorStateInfo info;
	private AnimationInfo[] teste;
	private bool pulo;
	private bool _isShoting;
	// Use this for initialization
	void Start () {
		anim =  GetComponent<Animator>();
		pulo = false;
		_isShoting = false;
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

public	void GoLeft() {
		GameObject.FindGameObjectWithTag ("left button").GetComponent<Animator> ().SetTrigger ("Pressionado");
		Vector3 aux = transform.localScale;
		Vector2 aux1 = rigidbody2D.velocity;
		aux1.x = -velocidade*Vector2.right.x;
		rigidbody2D.velocity = aux1;
		aux.x=1;
		transform.localScale = aux;
		_isfacedRight = false;
		anim.SetTrigger("correndo");

	}

public	void GoRight() {
		GameObject.FindGameObjectWithTag ("right button").GetComponent<Animator> ().SetTrigger ("Pressionado");
		Vector3 aux = transform.localScale;
		Vector2 aux1 = rigidbody2D.velocity;
		aux1.x = velocidade*Vector2.right.x;
		rigidbody2D.velocity = aux1;
		aux.x=-1;
		transform.localScale = aux;
		_isfacedRight = true;
		anim.SetTrigger("correndo");
	}

	public void Jump() {
		GameObject.FindGameObjectWithTag ("jump button").GetComponent<Animator> ().SetTrigger ("Pressionado");
		if(!pulo)
		{
			Vector2 aux = rigidbody2D.velocity;
			aux.y = 18*Vector2.up.y;
			rigidbody2D.velocity = aux;
			pulo = true;
		}
	}
public	void Atirar(){
		GameObject.FindGameObjectWithTag ("fire button").GetComponent<Animator> ().SetTrigger ("Pressionado");
		if (!_isShoting) {
			anim.SetTrigger("atirando");
				_isShoting = true;
				Invoke ("Atirar1", 0.4f);
				}
	}
	private void Atirar1(){
		_isShoting = false;
		instanciarBala();
	}

	void instanciarBala(){
		_missile = PhotonNetwork.Instantiate(missile.name, Vector3.zero, Quaternion.identity, 0);
		_missile.transform.parent = gameObject.transform;
	//	_missile.GetComponent<ManagerMissile> ().facedRight = _isfacedRight;
		ManagerMissile manager = _missile.GetComponent<ManagerMissile>();
		manager.enabled = true;
		manager.facedRight = _isfacedRight;
		BoxCollider2D colisor = _missile.GetComponent<BoxCollider2D>();
		colisor.enabled = true;

	}

	void OnCollisionStay2D(Collision2D hit)
	{
		if(hit.collider.tag == "floor")
		{
			pulo = false;
		}
	}


}
