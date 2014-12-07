using UnityEngine;
using System.Collections;

public class SeguidorCamera : MonoBehaviour {

	public GameObject camera;
	public float limitMaxX = 100;
	public float limitMinX = 0;
	public float limitMaxY;
	public float limitMinY;
	private float halfHeightScreen;
	private float halfWidthScreen;
	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		camera.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void LimitesCamera()
	{
		if (transform.position.x > limitMaxX-halfWidthScreen) 
			camera.transform.position = new Vector3 (limitMaxX-halfWidthScreen, transform.position.y, transform.position.z);
		else if(transform.position.x < limitMinX+halfWidthScreen)
			camera.transform.position = new Vector3 (limitMinX+halfWidthScreen, transform.position.y, transform.position.z);
		else
			camera.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		if (transform.position.y < limitMinY+halfHeightScreen) 
			camera.transform.position = new Vector3 (transform.position.x, limitMinY+halfHeightScreen, transform.position.z);
		else if (transform.position.y > limitMaxY-halfHeightScreen)
			camera.transform.position = new Vector3 (transform.position.x, limitMaxY-halfHeightScreen, transform.position.z);
		else
			camera.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

	}
}
