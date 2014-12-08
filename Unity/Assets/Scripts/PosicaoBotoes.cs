using UnityEngine;
using System.Collections;

public class PosicaoBotoes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TranformPosicao()
	{

		bool faceright;
		faceright = GetComponentInParent<Controles> ()._isfacedRight;
		transform.localScale = new Vector3 (1, 1, 1);
		if (faceright)
			transform.localScale = new Vector3 (-1, 1, 1);

	}
}
