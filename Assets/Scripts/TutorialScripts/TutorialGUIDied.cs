using UnityEngine;
using System.Collections;
using System;

public class TutorialGUIDied : IGUI {
	
	public event Action OkClicked;
	public event Action CancelClicked;

	//private GUIStyle backgroundBoxStyle;
	private int GUIWidth;						// Defines the GUI background width
	private int GUIHeight; 						// Defines the GUI background height
	private int GUIPosX; // Defines the GUI position on the X axis
	private int GUIPosY; 	// Defines the GUI position on the Y axis
	private int buttonWidth;
	private int buttonHeight;
	
	private Texture crossTexture;
	private Texture circleTexture;
	private GUIContent OKButtonContent;
	private GUIContent CancelButtonContent;
	private Texture starFull;
	private Texture starEmpty;
	
	static TutorialGUIDied ()
	{
		instance = new TutorialGUIDied ();
	}
	
	public static TutorialGUIDied Instance { get { return instance; } }

	private static TutorialGUIDied instance;
	
	private TutorialGUIDied ()
	{
		//	backgroundBoxStyle.normal.background = Resources.Load ("Box_background") as Texture2D;
		
		GUIWidth = 800; 						
		GUIHeight = 500; 						
		GUIPosX = (Screen.width - GUIWidth) / 2; 	
		GUIPosY = (Screen.height - GUIHeight) / 2; 	
		buttonWidth = 200;
		buttonHeight = 50;
		
		crossTexture = Resources.Load("psbuttons/cross") as Texture;
		circleTexture = Resources.Load("psbuttons/circle") as Texture;
		OKButtonContent = new GUIContent(" RELOAD", crossTexture);		
		CancelButtonContent = new GUIContent(" EXIT TUTORIAL", circleTexture);
	}
	
	public void Draw ()
	{
		Color backgroundColor = new Color (0.4f, 0.4f, 0.4f, 1.0f); // Light Grey
		
		// Draws the box background
		GUI.backgroundColor = backgroundColor;
		GUI.Box (new Rect (GUIPosX, GUIPosY, GUIWidth, GUIHeight), string.Empty, GUIStyles.backgroundBoxStyle);
		
		// Draws the message
		GUI.Label (new Rect (GUIPosX, GUIPosY + 50, GUIWidth, GUIHeight), "YOU HAVE DIED!", GUIStyles.upperCenterTextStyle);

		if(GUI.Button (new Rect (GUIPosX + 100, GUIPosY + GUIHeight * 3 / 4 + buttonHeight / 2, buttonWidth, buttonHeight), OKButtonContent))
			this.OkClicked ();
		if(GUI.Button (new Rect (GUIPosX + GUIWidth - buttonWidth - 100, GUIPosY + GUIHeight * 3 / 4 + buttonHeight / 2, buttonWidth, buttonHeight), CancelButtonContent))
			this.CancelClicked ();
	}
	
	public void XPressed ()
	{
		this.OkClicked();
	}
	
	public void OPressed() {
		this.CancelClicked();	
	}
}
