using UnityEngine;
using System.Collections;

public class Seletor : MonoBehaviour {
	private int count;
	private int LimitMax, LimitMin;

	void OnMouseDown()
	{

		
		if (transform.name == "Seletor Esquerdo") {

			count--;
			CheckPosicao ();
			PlayerPrefs.SetInt("escolha",count);
		}
		if (transform.name == "Seletor Direito") {

			count++;
			CheckPosicao ();
			PlayerPrefs.SetInt("escolha",count);
		}
	}
	// Use this for initialization
	void Start () {
		count = 1;	
		LimitMax = 2;
		LimitMin = 1;
	}

	void CheckPosicao()
	{
		if (count > 2)
						count = 1;
		if (count < 1)
						count = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
