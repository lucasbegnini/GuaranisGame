using UnityEngine;
using System.Collections;

public class SeguidorCamera : MonoBehaviour {

	//public GameObject camera;
	public float limitMaxX;
	public float limitMinX;
	public float limitMaxY;
	public float limitMinY;
	private float halfHeightScreen;
	private float halfWidthScreen;
	// Use this for initialization
	void Start () {
		//camera = GameObject.FindGameObjectWithTag ("MainCamera");
		//camera.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		LimitesCamera ();
	}

	void LimitesCamera()
	{
		if ((transform.position.x < limitMaxX) && (transform.position.x > limitMinX) && (transform.position.y < limitMaxY) && (transform.position.y > limitMinY)) 
		{
						Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y, Camera.main.transform.position.z);
		}

	}
}
