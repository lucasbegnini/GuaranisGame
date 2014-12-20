using UnityEngine;
using System.Collections;

public class Round : MonoBehaviour {

	private GameObject telafinal;
	private bool _isPlaying;
	private int trofeuN;
	// Use this for initialization
	void Start () {
		telafinal = GameObject.FindGameObjectWithTag ("telafinal");
		_isPlaying = false;
		trofeuN = 1;
		habilitarBotoes (false);

	}
	
	// Update is called once per frame
	void Update () {
	
		if( (PhotonNetwork.playerList.Length > 2) && (PhotonNetwork.connectionStateDetailed.ToString() == "Joined"))
		{
			telafinal.SetActive (false);
			_isPlaying = true;
			habilitarBotoes(true);
		}

		if ( (PhotonNetwork.playerList.Length == 1) && (_isPlaying))
		{
			GameObject.FindGameObjectWithTag("trofeu"+ trofeuN.ToString()).GetComponent<SpriteRenderer>().enabled = true;
			trofeuN++;
			Die();
		}
	}

	void habilitarBotoes(bool entrada)
	{
		GameObject.FindGameObjectWithTag ("right button").SetActive (entrada);
		GameObject.FindGameObjectWithTag ("left button").SetActive (entrada);
		GameObject.FindGameObjectWithTag ("jump button").SetActive (entrada);
		GameObject.FindGameObjectWithTag ("fire button").SetActive (entrada);
	}

	public void Die()
	{
		_isPlaying = false;
		telafinal.SetActive (true);
		habilitarBotoes (false);
	}
}
