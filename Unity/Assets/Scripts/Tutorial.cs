using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	private Vector2 _minTela;
	private Vector2 _maxTela;
	public GameObject carapana;
	private GameObject _carapana;
	public GameObject personagem;
	private GameObject _personagem;
	private Vector3 posicao;
	
	// Use this for initialization
	void Start () {
		_minTela = new Vector2(-11,-12);
		_maxTela = new Vector2(11,1);
		posicao = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, 0.0f);
		CriaPersonagem();
		CriaCarapana();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CriaPersonagem()
	{
		_personagem = GameObject.Instantiate(personagem, posicao, Quaternion.identity)as GameObject;



	}
	public void CriaCarapana(){
		_carapana = GameObject.Instantiate(carapana) as GameObject;
		float aleatorioX = Random.Range(_minTela.x,_maxTela.x);
		float aleatorioY = Random.Range(_minTela.y,_maxTela.y);
		Vector2 posicao = new Vector2(aleatorioX,aleatorioY);
		_carapana.transform.position = posicao;
		_carapana.transform.parent = transform; 
	}
}
