using UnityEngine;
using System.Collections;

public class RandomMathmaker : MonoBehaviour {
	
	private string PersonagemSelecionado;
	private Vector3 posicao;

	// Use this for initialization
	void Start () {
		posicao = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, 0.0f);
		PersonagemSelecionado = "Uiapuru";
	
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null, roomOptions,TypedLobby.Default);
	}



	void OnJoinedRoom()
	{

		//NameNave = FindObjectOfType<GameStarter> ().naves[SelectArrow.nave].name.ToString ();
		//Debug.Log(NameNave);

		GameObject personagem = PhotonNetwork.Instantiate(PersonagemSelecionado, posicao, Quaternion.identity, 0);

		//Ativa os controles do personagens
		Controles controller = personagem.GetComponent<Controles>();
		controller.enabled = true;
		SeguidorCamera camera = personagem.GetComponent<SeguidorCamera>();
		camera.enabled = true;
		VirtualJoystick shoot = personagem.GetComponent<VirtualJoystick> ();
		shoot.enabled = true;
		Life life = personagem.GetComponent<Life> ();
		life.enabled = true;
		NetworkCharacter network = personagem.GetComponent<NetworkCharacter> ();
		network.enabled = true;
		BoxCollider2D Colisor = personagem.GetComponent<BoxCollider2D> ();
		Colisor.enabled = true;
		Animator animacoes = personagem.GetComponent<Animator> ();
		animacoes.enabled = true;
		//Ativa o colisor do personagem
	
	}
	// Update is called once per frame
	void Update () {
	
	}

}
