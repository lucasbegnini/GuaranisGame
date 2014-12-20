using UnityEngine;
using System.Collections;

public class Round : MonoBehaviour {

	private GameObject telafinal;
	private bool _isPlaying;
	private int trofeuN;
	private bool fimdeJogo;
	private Trofeus troufeus;
	// Use this for initialization
	void Start () {
		troufeus = GameObject.FindGameObjectWithTag ("trofeuGO").GetComponent<Trofeus>();
		telafinal = GameObject.FindGameObjectWithTag ("telafinal");
		fimdeJogo = false;
		_isPlaying = false;
		trofeuN = 1;
		troufeus.setTrofeus ();
		habilitarBotoes (false);

	}

	public bool getFimdeJogo()
	{
		return fimdeJogo;
	}

	public void setFimdeJogo(bool entrada)
	{
		fimdeJogo = entrada;
	}

	void checkFim()
	{
		if(fimdeJogo == true)
		{
			if(trofeuN >= 3)
			{
				//Carrega oq e pra ser feito se ele vencer
				Debug.Log ("Ele venceu!!");

			}else {
			 	//Carregar oq pra ser feito se ele morrer
				Debug.Log ("Ele perdeu!!");
				Application.LoadLevel("Menu");
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		if( PhotonNetwork.playerList.Length == 2 )
		{
			telafinal.SetActive (false);
			_isPlaying = true;
			habilitarBotoes(true);
		}

		if ( (PhotonNetwork.playerList.Length == 1) && (_isPlaying))
		{
			DieVencedor();
		}


	}

	void habilitarBotoes(bool entrada)
	{
		GameObject.FindGameObjectWithTag ("right button").GetComponent<SpriteRenderer>().enabled = entrada;
		GameObject.FindGameObjectWithTag ("right button").GetComponent<SphereCollider>().enabled = entrada;
		
		GameObject.FindGameObjectWithTag ("left button").GetComponent<SpriteRenderer>().enabled = entrada;
		GameObject.FindGameObjectWithTag ("left button").GetComponent<SphereCollider>().enabled = entrada;
		
		GameObject.FindGameObjectWithTag ("jump button").GetComponent<SpriteRenderer>().enabled = entrada;
		GameObject.FindGameObjectWithTag ("jump button").GetComponent<SphereCollider>().enabled = entrada;
		
		GameObject.FindGameObjectWithTag ("fire button").GetComponent<SpriteRenderer>().enabled = entrada;
		GameObject.FindGameObjectWithTag ("fire button").GetComponent<SphereCollider>().enabled = entrada;

	}

	public void Die()
	{
		troufeus.SaveTrofeus ();
		_isPlaying = false;
		telafinal.SetActive (true);
		habilitarBotoes (false);
		PhotonNetwork.Disconnect ();
		checkFim ();
	}

	public void DieVencedor()
	{
		troufeus.SaveTrofeus ();
		//PhotonNetwork.Disconnect ();
		_isPlaying = false;
		telafinal.SetActive (true);
		habilitarBotoes (false);
		Invoke ("checkFim", 1.0f);
		Invoke ("AtivarTrofeu", 0.1f);

	}

	void AtivarTrofeu()
	{
		trofeuN = troufeus.getTrofeus ();
		for( int i = 0; i<= trofeuN; i++)
		{
		GameObject.FindGameObjectWithTag("trofeu"+ (i+1).ToString()).GetComponent<SpriteRenderer>().enabled = true;
		}
		if(trofeuN == 3)
		{
			fimdeJogo = true;
		}
		Invoke ("checkFim", 1.0f);
		troufeus.setTrofeus ();
		
	}
}
