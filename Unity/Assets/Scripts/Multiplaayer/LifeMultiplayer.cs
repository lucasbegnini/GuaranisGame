using UnityEngine;
using System.Collections;

public class LifeMultiplayer : MonoBehaviour {
	private int Vida;
	public GameObject Folha;
	private GameObject[] _Folha;
	private Vector3 posicaoFolha;
	private Collider2D ColisorPersonagem;
	private int PlayerID;
	private Animator anim;
	Controles controle;
	private Transform correctPosition;
//	private SFXSinglePlayer sounds;
	private GameObject roundControl;
//	private SFXSinglePlayer sounds;
	// Use this for initialization


	void Start () {
		roundControl = GameObject.FindGameObjectWithTag ("round");
		controle = GetComponent<Controles> ();
		anim = GetComponent<Animator> ();
	//	sounds = GameObject.FindGameObjectWithTag ("sfx").GetComponent<SFXSinglePlayer> ();
//		sounds = GameObject.FindGameObjectWithTag ("sfx").GetComponent<SFXSinglePlayer> ();
		PlayerID = PhotonNetwork.player.ID;
		Vida = 3; 

		
	}
	public int  Retornaid()
	{
		return PhotonNetwork.player.ID;
		
	}

	public void CriarFolhas()
	{
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
		PhotonNetwork.Destroy (gameObject);
		PhotonNetwork.Disconnect ();
		roundControl.GetComponent<Round> ().Die();

	}
	
	// Funçao para causar dano no personagem
	void takeDamage(int dano)
	{
		//Habilita o som de morte
//		sounds.setMorrendo (true);
		//Desabilita os controles
//		controle.enabled = false;
		//Primeiro sofre o dano 
		for(int i = 0; i< dano; i++)
		{
			Vida--;
//			Destroy(_Folha[Vida]);
		}
		
		//Se ele estiver no modo Online - Multiplayer
		if(PhotonNetwork.connected)
		{
			
		}
		//Se ele estiver no modo Offline - SinglePlay
		if(!PhotonNetwork.connected)
		{
			//Destroi o objeto Online - Dardo
			PhotonNetwork.Destroy(ColisorPersonagem.gameObject);
			
		}
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
		
		//Verifica se esta no modo offline(SiglePlay)
		if(!PhotonNetwork.connected)
		{
			
			//Verifica se o objeto colidido foi o carapana
			if (ColisorPersonagem.gameObject.CompareTag("carapana")) 
			{
				//Sofre 1 de dano
				takeDamage(1);
			}
		}
		
		//Verifica se esta no modo online(Multiplayer)
		if (PhotonNetwork.connected)
		{
			
			//Verifica se o objeto colidido foi o dardo e se esse dardo nao pertence ao mesmo
			if(ColisorPersonagem.gameObject.CompareTag("dardo") && (c.gameObject.GetComponent<ManageMissileMultiplayer>().Pai != Retornaid())  )
			{
//				sounds.setMorrendo (true);
				//Sofre 1 de dano
				takeDamage(1);
			}
		}//Fim do If de conexao
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
		Invoke ("Normal", 1f);
	}
	
	//Metodo para fazer o personagem sair do modo Ghost e desativar a animaçao morrendo
	void Normal()
	{
		//seta o fim do som de morrendo
	//	sounds.setMorrendo (false);
		//Desativa a animaçao morrendo
		anim.SetBool ("morrendo", false);
		//Seta possivel a colisao entre o personagem e objeto colidido novamente
		Physics2D.IgnoreCollision (ColisorPersonagem, collider2D, false);
		//Habilita o controle de volta
		controle.enabled = true;
		//seta o fim do som de morrendo
//		sounds.setMorrendo (false);
	}

}
