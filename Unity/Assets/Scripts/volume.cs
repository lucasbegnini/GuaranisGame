using UnityEngine;
using System.Collections;

public class volume : MonoBehaviour {
	public Sprite on;
	public Sprite off;
	bool sound = true;

	void Start()
	{
		SpriteRenderer r = renderer as SpriteRenderer;
		r.sprite = on;
	}
	void OnMouseDown()
	{
		SpriteRenderer r = renderer as SpriteRenderer;


		if (sound) {
		
			AudioListener.pause = true;
			r.sprite = off;
			sound = false;

		}else if (!sound) {
		
			AudioListener.pause = false;
			sound = true;
			r.sprite = on;
		}
						

	}



}
