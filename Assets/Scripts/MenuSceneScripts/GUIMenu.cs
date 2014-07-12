using UnityEngine;
using System.Collections;
using System;

public class GUIMenu : MonoBehaviour
{
	
	public event Action PlayClicked;
	public event Action QuitClicked;
	public event Action TutorClicked;
	
	[HideInInspector] public int buttonSelected;
	public Texture clone;
	public Texture cloneI;
	//public Texture2D cloneI;
//	private	uint GUIWidth; 	// Defines the GUI background width
//	private uint GUIHeight; // Defines the GUI background height
//	private uint GUIPosX; 	// Defines the GUI position on the X axis
//	private uint GUIPosY; 	// Defines the GUI position on the Y axis
	private uint buttonWidth;
	private uint buttonHeight;
	
//	[HideInInspector] public string sessionID;
	
	void Awake()
	{
		this.buttonSelected = 1;	
	}
	
	// Use this for initialization
	void Start ()
	{
//		GUIWidth = 500; 						
//		GUIHeight = 300; 						
//		GUIPosX = (uint) (Screen.width-GUIWidth)/2; 	
//		GUIPosY = (uint) (Screen.height-GUIHeight)/2; 	
		buttonWidth = 250;
		buttonHeight = 60;
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, Screen.height / 2 - buttonHeight, buttonWidth, buttonHeight), "! PLAY !", GUIStyles.laserTextStyle)) {
			this.PlayClicked ();
		}
	
		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, Screen.height / 2 + buttonHeight / 2, buttonWidth, buttonHeight), "! TUTORIAL !", GUIStyles.laserTextStyle)) {
			this.TutorClicked();	
		}
	
		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2, Screen.height / 2 + 2*buttonHeight, buttonWidth, buttonHeight), "! QUIT !", GUIStyles.laserTextStyle)) {
			this.QuitClicked ();
		}
		
		//Draws the icon highlighting selected option
		GUI.DrawTexture(new Rect(Screen.width/2 - buttonWidth / 2 - 80,Screen.height/2 - buttonHeight + (buttonSelected-1) * (buttonHeight * 1.5f),100.0f,60.0f), clone, ScaleMode.ScaleToFit, true, 0.0f);
		GUI.DrawTexture(new Rect(Screen.width/2 + buttonWidth / 2 - 20, Screen.height/2 - buttonHeight + (buttonSelected-1) * (buttonHeight * 1.5f) ,100.0f,60.0f), cloneI, ScaleMode.ScaleToFit, true, 0.0f);	

		
		//Accept the session ID
//		GUI.Label (new Rect (Screen.width * 0.8f, Screen.height * 0.9f, 150f, 30f), "Session ID:", GUIStyles.upperTextStyle);
//		sessionID = GUI.TextField (new Rect (Screen.width * 0.93f, Screen.height * 0.9f, 50f, 30f), sessionID);//, GUIStyles.upperTextStyle);
	}
	
	public void selectedButton(int botao)
	{
		buttonSelected = botao;		
	}	
}
