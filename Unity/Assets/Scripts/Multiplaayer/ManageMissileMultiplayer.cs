using UnityEngine;
using System.Collections;

public class ManageMissileMultiplayer :Photon.MonoBehaviour {
	public float speed;
	public bool facedRight;
	public int Pai;
	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;
	private Vector3 correctPlayerScale;
	// Use this for initialization
	void Start () {
		Vector3 playerCenter = transform.parent.transform.position;
		if(facedRight){
			rigidbody2D.velocity = new Vector2(speed,0);
			Vector3 vect = transform.localScale;
			vect.x *= -1;
			transform.localScale = vect;
		}
		else{
			rigidbody2D.velocity = new Vector2(-speed,0);
		}
		transform.position = playerCenter;
		Pai = transform.parent.gameObject.GetComponent<LifeMultiplayer>().Retornaid();
		transform.parent = null;
		Invoke("Kill",3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!photonView.isMine) 
		{
			transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime);
			transform.localScale = this.correctPlayerScale;
		}
	}
	
	public int  Retornaid()
	{
		return PhotonNetwork.player.ID;
		
	}
	
	void Starting(){
		Vector3 playerCenter = transform.parent.transform.position;
		if(facedRight){
			rigidbody2D.velocity = new Vector2(speed,0);
			Vector3 vect = transform.localScale;
			vect.x *= -1;
			transform.localScale = vect;
		}
		else{
			rigidbody2D.velocity = new Vector2(-speed,0);
		}
		transform.position = playerCenter;
		transform.parent = null;
	}
	
	void OnCollisionEnter2D(Collision2D c){
		if(!c.gameObject.CompareTag("Player"))
			Kill();
	}
	
	void Kill(){
	
			PhotonNetwork.Destroy (gameObject);
	
	}  
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.position);
			//stream.SendNext(transform.rotation);
			stream.SendNext(transform.localScale);
			//			stream.SendNext(rigidbody2D.velocity);
			
			
		}
		else
		{
			// Network player, receive data
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			//this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			this.correctPlayerScale = (Vector3)stream.ReceiveNext();
			//			this.ridigbodyPlayer = (Rigidbody2D)stream.ReceiveNext();
			
		}
		
	}
}
