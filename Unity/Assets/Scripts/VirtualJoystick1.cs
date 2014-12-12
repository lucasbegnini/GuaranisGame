using UnityEngine;
using System.Collections;

public class VirtualJoystick1 : MonoBehaviour {
	
	public LayerMask whatIsButton;
	private Controles1 characterController;
	//private Shoot shoot;
	private int controlType=1;
	void Start () {

		characterController = GetComponent<Controles1> ();

	//	shoot = GetComponent<Shoot> ();
	//	controlType = PlayerPrefs.GetInt("Controls");
	}

	void FixedUpdate () {
		//characterController.GoLeft();
		int touchCont = Input.touchCount;
		for(int i = 0 ; i < touchCont;i++){
			
			Touch touch = Input.GetTouch(i);
			RaycastHit hit;
			Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
			if (controlType == 1) {
				if(Physics.Raycast(touchPos,Vector3.forward, out hit,whatIsButton)){
					
					if(hit.collider.tag == "left button")
						characterController.GoLeft();
					else if(hit.collider.tag == "right button")
						characterController.GoRight();
					else
						characterController.Stop();
					if(hit.collider.tag == "fire button")
							characterController.Atirar();
					if(hit.collider.tag == "jump button")
						characterController.Jump();
						//GetComponent<Animator> ().SetBool("acelerando",true);
				}
			}
		}
	}
}
