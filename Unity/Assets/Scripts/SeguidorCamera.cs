using UnityEngine;
using System.Collections;

public class SeguidorCamera : MonoBehaviour {

	public GameObject camera;
	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		camera.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
