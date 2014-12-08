using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	private int Vida;
	public GameObject Folha;
	private GameObject[] _Folha;
	private Vector3 posicaoFolha;

	// Use this for initialization
	void Start () {
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

	void OnCollisionEnter2D(Collision2D other)
	{	

		if (other.collider.tag == "dardo" && other.transform.parent == transform){
			//Tira o life
			Vida--;		
			// Destroi o Dardo
			//PhotonNetwork.Destroy(gameObject);
			Destroy(other.gameObject);
			CheckLife ();
		}

	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.CompareTag("carapana")) {

			Vida--;
			Destroy(_Folha[Vida]);
			CheckLife();

		}
	}
}
