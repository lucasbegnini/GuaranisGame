using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {
		
	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;
	private Vector3 correctPlayerScale;
	private Rigidbody2D ridigbodyPlayer;
	Animator animacao;
	//private AnimationInfo info;
	void Start()
	{
		animacao = GetComponent<Animator> ();
	}

	void Update()
	{
		if (!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
			transform.rotation = this.correctPlayerRot;
			transform.localScale = this.correctPlayerScale;
//			rigidbody2D.velocity = this.ridigbodyPlayer.velocity;

			//animation = animacao.animation;



		}
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(transform.localScale);
			stream.SendNext(animacao.GetBool("correndo"));
			stream.SendNext(animacao.GetBool("atirando"));
			stream.SendNext(animacao.GetBool("morrendo"));
//			stream.SendNext(rigidbody2D.velocity);

			
		}
		else
		{
			// Network player, receive data
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			this.correctPlayerScale = (Vector3)stream.ReceiveNext();
			animacao.SetBool("correndo",(bool)stream.ReceiveNext());
			animacao.SetBool("atirando",(bool)stream.ReceiveNext());
			animacao.SetBool("morrendo",(bool)stream.ReceiveNext());
			//			this.ridigbodyPlayer = (Rigidbody2D)stream.ReceiveNext();

		}
	}
}
