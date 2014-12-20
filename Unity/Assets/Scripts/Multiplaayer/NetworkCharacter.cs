using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {
		
	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;
	private Vector3 correctPlayerScale;
	private Rigidbody2D ridigbodyPlayer;
	private Vector2 correctVelocity;
	private Vector2 correctForce;
	Animator animacao;
	private float startTime;
	public float speed;
	private float journeyLength;
	private Round round;
	private SFXSinglePlayer sfx;
	//SFXSinglePlayer sons;
	//private AnimationInfo info;
	void Start()
	{
		round = GameObject.FindGameObjectWithTag ("round").GetComponent<Round> ();
		startTime = Time.time;
		sfx = GameObject.FindGameObjectWithTag ("sfx").GetComponent<SFXSinglePlayer> ();
		//sons = GameObject.FindGameObjectWithTag ("sfx").GetComponent<SFXSinglePlayer> ();
		animacao = GetComponent<Animator> ();
		speed = GetComponent<Controles>().getVelocidade();
	}

	void Update()
	{
		if (!photonView.isMine)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, fracJourney);
//			transform.position = this.correctPlayerPos;
	//		transform.rotation = Quaternion.Lerp(transform.rotation,this.correctPlayerRot,Time.deltaTime *5);
			transform.localScale =this.correctPlayerScale; 
			rigidbody2D.velocity = this.correctVelocity;
			//animation = animacao.animation;



		}
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.position);
	//		stream.SendNext(transform.rotation);
			stream.SendNext(transform.localScale);
			stream.SendNext(animacao.GetBool("correndo"));
			stream.SendNext(animacao.GetBool("atirando"));
			stream.SendNext(animacao.GetBool("morrendo"));
			stream.SendNext(rigidbody2D.velocity);
			stream.SendNext(round.getFimdeJogo());
			stream.SendNext(sfx.getMorrendo());
			stream.SendNext(sfx.getAtirando());

			
		}
		else
		{
//			// Network player, receive data
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
	//		this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			this.correctPlayerScale = (Vector3)stream.ReceiveNext();
			animacao.SetBool("correndo",(bool)stream.ReceiveNext());
			animacao.SetBool("atirando",(bool)stream.ReceiveNext());
			animacao.SetBool("morrendo",(bool)stream.ReceiveNext());
			this.correctVelocity = (Vector2)stream.ReceiveNext();
			round.setFimdeJogo((bool)stream.ReceiveNext());
			sfx.setMorrendo((bool)stream.ReceiveNext());
			sfx.setAtirando((bool)stream.ReceiveNext());
		}
	}
}
