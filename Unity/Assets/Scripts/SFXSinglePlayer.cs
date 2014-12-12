using UnityEngine;
using System.Collections;

public class SFXSinglePlayer : MonoBehaviour {

	private bool _morrendo;
	private bool _atirando;
	private bool _pulando;
	public AudioSource morrendoSFX;
	public AudioSource atirandoSFX;
	public AudioSource pulandoSFX;

	// Metodos set e get para o trigger Pulando
	public bool getPulando()
	{
		return _pulando;
	}
	
	public void setPulando(bool entrada)
	{
		_pulando = entrada;
	}
	// Metodos set e get para o trigger Morrendo
	public bool getMorrendo()
	{
		return _morrendo;
	}

	public void setMorrendo(bool entrada)
	{
		_morrendo = entrada;
	}

	//Metodos set e get para o trigger atirando
	public bool getAtirando()
	{
		return _atirando;
	}
	
	public void setAtirando(bool entrada)
	{
		_atirando = entrada;
	}

	//Metodo para tocar os sons
	void checkSounds()
	{
		// Se o personagem estiver atirando
		if (_atirando) 
		{
			//A posicao do som vai ser a mesma do personagem

			atirandoSFX.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
			//Toca o som 
			atirandoSFX.Play();

		}

		//Se o personagem estiver morrendo
		if(_morrendo)
		{
			//A posicao do som vai ser a mesma do personagem
			morrendoSFX.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
			//Toca o som 
			morrendoSFX.Play();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		checkSounds ();
	}
}
