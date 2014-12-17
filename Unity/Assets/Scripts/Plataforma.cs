using UnityEngine;
using System.Collections;

public class Plataforma : MonoBehaviour {

	private Transform Player;
	// Use this for initialization
	void Start () {
		GetComponent<EdgeCollider2D> ().enabled = false;
		GetComponent<CircleCollider2D> ().enabled = false;
	

	}
	
	// Update is called once per frame
	void Update () {

	

		if (PhotonNetwork.connected) {
			PlataformaSinglePlay();		
		}
		if (!PhotonNetwork.connected) {
			PlataformaSinglePlay();		
		}


	}

	void PlataformaMultiPlay()
	{
		GetComponent<EdgeCollider2D> ().enabled = true;
		GetComponent<CircleCollider2D> ().enabled = true;
	}

	void PlataformaSinglePlay()
	{
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		if ((Player.position.y -1.5f )> transform.position.y) {
			
			GetComponent<EdgeCollider2D> ().enabled = true;
			GetComponent<CircleCollider2D> ().enabled = true;
		} else {
			
			GetComponent<CircleCollider2D> ().enabled = false;
			GetComponent<EdgeCollider2D> ().enabled = false;		
		}
	}
}
