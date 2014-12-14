using UnityEngine;
using System.Collections;

public class Controles1 : MonoBehaviour {

	static int deltaTime = 1;
	public int velocidade;
	public GameObject missile;
	private GameObject _missile;
	private Animator anim;
	public bool _isfacedRight;
	private AnimatorStateInfo info;
	private AnimationInfo[] teste;
	private bool pulo;
	private bool _isShoting;
	private bool _onFloor;
	private SFXSinglePlayer sounds;

	// Use this for initialization
	void Start () {
		anim =  GetComponent<Animator>();
		sounds = GameObject.FindGameObjectWithTag ("sfx").GetComponent<SFXSinglePlayer> ();
		pulo = false;
		_isShoting = false;

	}
	
	// Update is called once per frame
	void Update ()  {
	
//		if(Input.GetKey(KeyCode.LeftArrow))
//			GoLeft();
//		else if(Input.GetKey(KeyCode.RightArrow))
//			GoRight();
//		else
//			Stop ();
//		if(Input.GetKeyDown(KeyCode.Space))
//			Jump();
//		if(Input.GetKeyDown(KeyCode.K)){
//			Atirar ();
//			
//		}
		
		
		
	}


	public void Stop()
	{
		
		anim.SetBool ("correndo", false);
		
	}


public	void GoLeft() {
		//GameObject.FindGameObjectWithTag ("left button").GetComponent<Animator> ().SetTrigger ("Pressionado");
		Vector3 aux = transform.localScale;
		Vector2 aux1 = rigidbody2D.velocity;
		aux1.x = -velocidade*Vector2.right.x;
		rigidbody2D.velocity = aux1;
		aux.x=1;
		transform.localScale = aux;
		_isfacedRight = false;
		if (!pulo)
		{
			anim.SetBool ("correndo", true);
		}	

	}

public	void GoRight() {
	//	GameObject.FindGameObjectWithTag ("right button").GetComponent<Animator> ().SetTrigger ("Pressionado");
		Vector3 aux = transform.localScale;
		Vector2 aux1 = rigidbody2D.velocity;
		aux1.x = velocidade*Vector2.right.x;
		rigidbody2D.velocity = aux1;
		aux.x=-1;
		transform.localScale = aux;
		_isfacedRight = true;
		if (!pulo)
		{
			anim.SetBool ("correndo", true);
		}
	}

	public void Jump() {
	//	GameObject.FindGameObjectWithTag ("jump button").GetComponent<Animator> ().SetTrigger ("Pressionado");
		if(!pulo)
		{
			sounds.setPulando(true);
			Vector2 aux = rigidbody2D.velocity;
			aux.y = 18*Vector2.up.y;
			rigidbody2D.velocity = aux;
			pulo = true;
		}
	}
public	void Atirar(){
	//	GameObject.FindGameObjectWithTag ("fire button").GetComponent<Animator> ().SetTrigger ("Pressionado");
		if (!_isShoting) {
			anim.SetBool("atirando",true);
			sounds.setAtirando(true);
				_isShoting = true;
				Invoke ("Atirar1", 0.4f);

				}
	}
	private void Atirar1(){
		_isShoting = false;
		instanciarBala();
		anim.SetBool("atirando",false);
		sounds.setAtirando (false);
	}

	void instanciarBala(){
		_missile = GameObject.Instantiate(missile) as GameObject;
		_missile.transform.parent = gameObject.transform;
	//	_missile.GetComponent<ManagerMissile> ().facedRight = _isfacedRight;
		ManagerMissile manager = _missile.GetComponent<ManagerMissile>();
		manager.enabled = true;
		manager.facedRight = _isfacedRight;


	}

	void OnCollisionStay2D(Collision2D hit)
	{
		if(hit.collider.tag == "floor")
		{
			pulo = false;
			sounds.setPulando(false);
		}
	}


}
