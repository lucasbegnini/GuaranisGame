using UnityEngine;
using System.Collections;

public class PlayNPause : MonoBehaviour {
	//bool paused = false;
	public Sprite Play;
	public Sprite Pause;

	void Start()
	{
		SpriteRenderer r = renderer as SpriteRenderer;
		r.sprite = Pause;

	}


	void Update()
	{
		
		
	}
	
	void OnMouseDown()
	{	
		
		togglePause();
		//audio.Play ();
	}
	
	
	

	
	bool togglePause()
	{
		SpriteRenderer r = renderer as SpriteRenderer;

		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			AudioListener.pause = false;
			r.sprite = Pause;
			GameObject.FindGameObjectWithTag("Filtro").GetComponent<SpriteRenderer>().enabled = false;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			AudioListener.pause = true;
			r.sprite = Play;
			GameObject.FindGameObjectWithTag("Filtro").GetComponent<SpriteRenderer>().enabled = true;
			return(true);   
		}
	}
	GUIStyle LoadStyleLabel()
	{	
		//GUI.color = Color.black;
		GUIStyle MyStyle;
		MyStyle = new GUIStyle (GUI.skin.label);
		MyStyle.fontSize = 25;
		// Load and set Font
		Font myFont = (Font)Resources.Load("Fonts/BradBunR", typeof(Font));
		MyStyle.font = myFont;
		
		
		return MyStyle;
	}

	GUIStyle LoadStyleButton()
	{	
		
		GUIStyle MyStyle;
		MyStyle = new GUIStyle (GUI.skin.button);
		MyStyle.fontSize = 20;
		// Load and set Font
		Font myFont = (Font)Resources.Load("Fonts/BradBunR", typeof(Font));
		MyStyle.font = myFont;
		
		
		return MyStyle;
	}
}