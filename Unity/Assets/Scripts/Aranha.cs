using UnityEngine;
using System.Collections;

public class Aranha : MonoBehaviour {

	private Vector2 _limitesXTela;
	public GameObject miniAranha;
	private GameObject _miniAranha;
	public GameObject aranha;
	public float speed;
	private Vector3 _novaPosicao;
	public GameObject personagem;
	private GameObject _personagem;
	// Use this for initialization
	void Start () {
		Vector3 posicao = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, 0.0f);
		_personagem = GameObject.Instantiate(personagem, posicao, Quaternion.identity) as GameObject;
		Invoke("NewWave",5);
		Invoke("AranhaIn",19);
		speed = 0.5f;
		_novaPosicao = aranha.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		aranha.transform.position = Vector3.Lerp(aranha.transform.position,_novaPosicao, Time.deltaTime * speed);
	}

	void NewWave(){
		for(int i=0;i<20;i++){
			Invoke("CriarMiniAranhas",0.7f*i);
		}
	}

	void CriarMiniAranhas(){
		_limitesXTela = new Vector2(-17f,17f);
		Vector3 _posicao = new Vector3(Random.Range(_limitesXTela.x,_limitesXTela.y),8,0);
		_miniAranha = GameObject.Instantiate(miniAranha) as GameObject;
		_miniAranha.transform.position = _posicao;

	}

	void AranhaIn(){
		speed = 0.5f;
		_novaPosicao = aranha.transform.position;
		_novaPosicao.y = -9;
		speed = 3;
		Invoke ("AranhaChange",3);
		Invoke ("AranhaChange",6);
		Invoke ("AranhaOut",10);
	}

	void AranhaChange(){
		_novaPosicao = aranha.transform.position;
		_novaPosicao.y = Random.Range(5,-13);
	}

	void AranhaOut(){
		speed = 10;
		_novaPosicao = aranha.transform.position;
		_novaPosicao.y = 15;
		NewWave();
		Invoke("AranhaIn",14);
	}
}
