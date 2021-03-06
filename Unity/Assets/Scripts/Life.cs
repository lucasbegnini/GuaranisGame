﻿using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	private int Vida;
	public GameObject Folha;
	private GameObject[] _Folha;
	private Vector3 posicaoFolha;
	private Collider2D ColisorPersonagem;
	private int PlayerID;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		PlayerID = PhotonNetwork.player.ID;
		Vida = 3; 
		_Folha = new GameObject[Vida];
		float distanciaX = 0.8f;
		float distanciaY = 1.5f;
		for(int i = 0; i < Vida; i++)
		{

			float posicaoFolhaX = GameObject.FindGameObjectWithTag ("HUD").transform.position.x - distanciaX;
			float posicaoFolhaY = GameObject.FindGameObjectWithTag ("HUD").transform.position.y - distanciaY;
		posicaoFolha = new Vector3 (posicaoFolhaX, posicaoFolhaY,0);

		_Folha[i] = Instantiate (Folha, posicaoFolha,Quaternion.identity) as GameObject;
		_Folha[i].transform.parent = GameObject.FindGameObjectWithTag ("MainCamera").transform;
			distanciaX = distanciaX - 0.7f;
		}
	
	}
	public int  Retornaid()
	{
		return PhotonNetwork.player.ID;

	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void CheckLife()
	{
		if (Vida <= 0) {
			Die();		
		}
	}

	void Die()
	{
		Destroy (this.gameObject);
		Application.LoadLevel (Application.loadedLevel);
	}

//	void OnCollisionEnter2D(Collision2D other)
//	{	
//
//		if (other.collider.tag == "dardo" && other.transform.parent == transform){
//			//Tira o life
//			Vida--;		
//			// Destroi o Dardo
//			//PhotonNetwork.Destroy(gameObject);
//			Destroy(other.gameObject);
//			CheckLife ();
//		}
//
//
//	}

	void OnTriggerEnter2D(Collider2D c)
	{

		ColisorPersonagem = c;
		if(!PhotonNetwork.connected)
		{
		if (ColisorPersonagem.gameObject.CompareTag("Aranha")) {
		
			Vida--;
			Destroy(_Folha[Vida]);
			CheckLife();
			Ghost();
			AnimacaoMorrendo();
			}
		}

		if (PhotonNetwork.connected)
		{

			if(ColisorPersonagem.gameObject.CompareTag("dardo") && (c.gameObject.GetComponent<ManagerMissile>().Pai != Retornaid())  )
			{
				Vida--;		
				// Destroi o Dardo
				Destroy(_Folha[Vida]);
				PhotonNetwork.Destroy(ColisorPersonagem.gameObject);
				CheckLife();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if(c.collider.CompareTag("Aranha")){
			
			Vida--;
			Destroy(_Folha[Vida]);
			CheckLife();
			Ghost();
			AnimacaoMorrendo();
		}
	}

	void Ghost()
	{
		Debug.Log ("Virou Fantasma");
		Physics2D.IgnoreCollision (ColisorPersonagem, collider2D, true);
	

		//Invoke ("Normal", 1f);
	}

	void AnimacaoMorrendo()
	{
		anim.SetBool ("morrendo", true);
		Invoke ("Normal", 0.8f);
	}

	void Normal()
	{
		Debug.Log ("Voltou ao normal");
		anim.SetBool ("morrendo", false);
		Physics2D.IgnoreCollision (ColisorPersonagem, collider2D, false);

	}

	void MovimentoDano()
	{
		transform.position = new Vector3 (transform.position.x - 2, transform.position.y - 2, transform.position.z);
	}
}
