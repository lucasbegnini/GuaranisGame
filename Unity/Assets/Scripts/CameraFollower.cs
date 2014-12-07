using UnityEngine;
using System.Collections;

public class CameraFollower: MonoBehaviour {
	private Transform target;
	public float limitMaxX = 100;
	public float limitMinX = 0;
	public float limitMaxY;
	public float limitMinY;
	private float halfHeightScreen;
	private float halfWidthScreen;
	private bool canShake=true;
	private float shakeAdjustX;
	private float shakeAmplitude;
	private float shakeMagnitude;
	private float shakeDuration;// 0.0000 a 1.
	
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
		halfWidthScreen= Vector3.Distance (Camera.main.ViewportToWorldPoint (Vector3.right), Camera.main.ViewportToWorldPoint (Vector3.right * 0.5f));
		halfHeightScreen = Vector3.Distance (Camera.main.ViewportToWorldPoint (Vector3.up), Camera.main.ViewportToWorldPoint (Vector3.up * 0.5f));

		}
	
	// Update is called once per frame
	void Update () {
		if(canShake)
			DoTheShake ();
		if (target.position.x > limitMaxX-halfWidthScreen) 
			transform.position = new Vector3 (limitMaxX-halfWidthScreen+shakeAdjustX, transform.position.y, transform.position.z);
		else if(target.position.x < limitMinX+halfWidthScreen)
			transform.position = new Vector3 (limitMinX+halfWidthScreen+shakeAdjustX, transform.position.y, transform.position.z);
		else
			transform.position = new Vector3 (target.position.x+shakeAdjustX, transform.position.y, transform.position.z);
		if (target.position.y < limitMinY+halfHeightScreen) 
			transform.position = new Vector3 (transform.position.x, limitMinY+halfHeightScreen, transform.position.z);
		else if (target.position.y > limitMaxY-halfHeightScreen)
			transform.position = new Vector3 (transform.position.x, limitMaxY-halfHeightScreen, transform.position.z);
		else
			transform.position = new Vector3 (transform.position.x, target.position.y, transform.position.z);
		
		
	}
	
	private void DoTheShake(){
		shakeAdjustX = Mathf.MoveTowards (shakeAdjustX, shakeAmplitude, shakeMagnitude * Time.deltaTime);
		if (shakeAdjustX == shakeAmplitude)
			shakeAmplitude *=-shakeDuration;
		if (Mathf.Abs (shakeAmplitude) < 0.001f) {
			canShake = false;
		}
		
		
	}
	
	public void shake(float magnitude, float amplitude, float duration){
		shakeAmplitude= amplitude;
		shakeMagnitude= magnitude;
		shakeDuration= duration;
		canShake = true;
	}
}
