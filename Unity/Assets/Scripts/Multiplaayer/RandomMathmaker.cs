using UnityEngine;
using System.Collections;

public class RandomMathmaker : MonoBehaviour {
	
	private string PersonagemSelecionado;
	private Vector3 posicao;


	void Escape()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			PhotonNetwork.Disconnect();
			Application.LoadLevel ("Menu");
				}
	}
	// Use this for initialization
	void Start () {
		posicao = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, 0.0f);
		getPersonagem ();
	
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void getPersonagem()
	{
		if (PlayerPrefs.GetInt ("escolha") == 1)
			PersonagemSelecionado = "Uiapuru";
		if (PlayerPrefs.GetInt ("escolha") == 2)
			PersonagemSelecionado = "Guarana";
		
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	}



	void OnJoinedRoom()
	{

		//NameNave = FindObjectOfType<GameStarter> ().naves[SelectArrow.nave].name.ToString ();
		//Debug.Log(NameNave);
		spawnPlayer ();


	
	}

	void spawnPlayer()
	{
		GameObject personagem = PhotonNetwork.Instantiate(PersonagemSelecionado, posicao, Quaternion.identity, 0);
		
		//Ativa os controles do personagens
		Controles controller = personagem.GetComponent<Controles>();
		controller.enabled = true;
		SeguidorCamera camera = personagem.GetComponent<SeguidorCamera>();
		camera.enabled = true;
		VirtualJoystick shoot = personagem.GetComponent<VirtualJoystick> ();
		shoot.enabled = true;
		LifeMultiplayer life = personagem.GetComponent<LifeMultiplayer> ();
		life.enabled = true;
//		NetworkCharacter network = personagem.GetComponent<NetworkCharacter> ();
//		network.enabled = true;
		BoxCollider2D Colisor = personagem.GetComponent<BoxCollider2D> ();
		Colisor.enabled = true;
		Animator animacoes = personagem.GetComponent<Animator> ();
		animacoes.enabled = true;
		//Ativa o colisor do personagem

	}
	// Update is called once per frame
	void Update () {
		Escape ();
	
	}

}
