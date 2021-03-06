﻿using UnityEngine;
using System.Collections;

public class NetworkBala : Photon.MonoBehaviour {

	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;
	private Vector3 correctPlayerScale;
	void Update()
	{
		if (!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
			//transform.rotation = this.correctPlayerRot;
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
			//stream.SendNext(transform.rotation);
			stream.SendNext(transform.localScale);
			//			stream.SendNext(rigidbody2D.velocity);
			
			
		}
		else
		{
			// Network player, receive data
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			//this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			this.correctPlayerScale = (Vector3)stream.ReceiveNext();
			//			this.ridigbodyPlayer = (Rigidbody2D)stream.ReceiveNext();
			
		}
	}

}
