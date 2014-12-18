using UnityEngine;
using System.Collections;

public class PosicaoIDPlayer : MonoBehaviour {
	int ID;
	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().sortingLayerName = "Botoes";
		ID = PhotonNetwork.player.ID;
		GetComponent<TextMesh> ().text = "Player " + ID.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		TranformPosicao ();
	
	}

	void TranformPosicao()
	{
		
		bool faceright;
		faceright = GetComponentInParent<Controles> ()._isfacedRight;
		transform.localScale = new Vector3 (0.1f, 0.1f, 1);
		if (faceright)
			transform.localScale = new Vector3 (-0.1f, 0.1f, 1);
		
	}
}
