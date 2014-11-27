//using UnityEngine;
//using System.Collections;
//
//public class VirtualJoystick : MonoBehaviour {
//	
//	public LayerMask whatIsButton;
//	private ShipMovement characterController;
//	private Shoot shoot;
//	void Start () {
//		characterController = GetComponent<ShipMovement> ();
//		shoot = GetComponent<Shoot> ();
//
//	}
//
//	void FixedUpdate () {
//
//		int touchCont = Input.touchCount;
//		for(int i = 0 ; i < touchCont;i++){
//			
//			Touch touch = Input.GetTouch(i);
//			RaycastHit hit;
//			Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
//			
//			if(Physics.Raycast(touchPos,Vector3.forward, out hit,whatIsButton)){
//				
//				if(hit.collider.tag == "left button")
//					characterController.MoveLeft();
//				else
//					if(hit.collider.tag == "right button")
//						characterController.MoveRight();
//				else 
//
//					if(hit.collider.tag == "fire button")
//						shoot.shoot();
//				if(hit.collider.tag == "thrust button"){
//					characterController.Thrust();
//					GetComponent<Animator> ().SetBool("acelerando",true);
//				}
//				else 
//					GetComponent<Animator> ().SetBool("acelerando",false);
//			}
//			
//		}
//	}
//}
