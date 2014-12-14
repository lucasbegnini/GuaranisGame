using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	private int Vida;
	public GameObject Folha;
	private GameObject[] _Folha;
	private Vector3 posicaoFolha;
	private Collider2D ColisorPersonagem;
	private int PlayerID;
	private Animator anim;
	Controles1 controle;
	private SFXSinglePlayer sounds;
	private Score setScore;
	// Use this for initialization
	void Start () {
		controle = GetComponent<Controles1> ();
		setScore = GameObject.FindGameObjectWithTag ("score").GetComponent<Score> ();
		sounds = GameObject.FindGameObjectWithTag ("sfx").GetComponent<SFXSinglePlayer> ();
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

	
	// Update is called once per frame
	void Update () {
	


	}

	void CheckLife()
	{
		if (Vida <= 0) {
			Invoke("Die", 0.8f);
			//Die();		
		}
	}

	void Die()
	{
			setScore.SaveScore ();
		Handheld.Vibrate ();
			Destroy (this.gameObject);
			Application.LoadLevel (Application.loadedLevel);
		
	}

	// Funçao para causar dano no personagem
	void takeDamage(int dano)
	{

		//Desabilita os controles
		controle.enabled = false;
		//Primeiro sofre o dano 
		for(int i = 0; i< dano; i++)
		{
			Vida--;
			Destroy(_Folha[Vida]);
		}


	
			//Destroi o objeto Online - Dardo
			//Destroy(ColisorPersonagem.gameObject);
			

		//Entra no modo Ghost
		Ghost();
		//Executa a animaçao morrendo
		AnimacaoMorrendo();
		//Faz o Check Se nao perdeu toda a vida ja
		CheckLife();
	}


	void OnTriggerEnter2D(Collider2D c)
	{
		//O Objeto colidido se torna um objeto da classe 
		ColisorPersonagem = c;

	
		//Verifica se o objeto colidido foi o carapana
		if (ColisorPersonagem.gameObject.CompareTag("carapana")) 
			{
			//Habilita o som de morte
			sounds.setMorrendo (true);
				//Sofre 1 de dano
				takeDamage(1);
			}
	}//Fim do Colisor



	//Metodo para deixar o personagem sem sofrere dano por um tempo
	// apos ter sofrido dano
	void Ghost()
	{
		//Ignora a coliçao entre o personagem e o objeto colidido - Seja Carapana(SinglePlay) ou um dardo(Multiplayer)
		Physics2D.IgnoreCollision (ColisorPersonagem, collider2D, true);
	}


	//Animaçao do personagem morrendo
	void AnimacaoMorrendo()
	{
		//Ativa a animaçao do personagem morrendo
		anim.SetBool ("morrendo", true);
		//Inova o metodo normal em seguida 
		Invoke ("Normal", 2f);
		Invoke ("NormalAnimacao", 1f);
	}

	void NormalAnimacao()
	{		
		//Desativa a animaçao morrendo
		anim.SetBool ("morrendo", false);
		//Habilita o controle de volta
		controle.enabled = true;

	}
	//Metodo para fazer o personagem sair do modo Ghost e desativar a animaçao morrendo
	void Normal()
	{

		//Seta possivel a colisao entre o personagem e objeto colidido novamente
		Physics2D.IgnoreCollision (ColisorPersonagem, collider2D, false);

		//seta o fim do som de morrendo
		sounds.setMorrendo (false);
	}


}// Fim da classes
