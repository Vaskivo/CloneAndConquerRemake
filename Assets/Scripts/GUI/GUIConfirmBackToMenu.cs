using UnityEngine;
using System.Collections;
using System;

public class GUIConfirmBackToMenu : IGUI
{
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
	
		
	static GUIConfirmBackToMenu ()
	{
		instance = new GUIConfirmBackToMenu ();
	}
	
	public static GUIConfirmBackToMenu Instance { get { return instance; } }

	private static GUIConfirmBackToMenu instance;
	
	private GUIConfirmBackToMenu ()
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
		OKButtonContent = new GUIContent(" OK", crossTexture);		
		CancelButtonContent = new GUIContent(" CANCEL", circleTexture);
	}
	
	public void Draw ()
	{
		Color backgroundColor = new Color (0.4f, 0.4f, 0.4f, 1.0f); // Light Grey
		
		// Draws the box background
		GUI.backgroundColor = backgroundColor;
		GUI.Box (new Rect (GUIPosX, GUIPosY, GUIWidth, GUIHeight), string.Empty, GUIStyles.backgroundBoxStyle);
		
		// Draws the message
		GUI.Label (new Rect (GUIPosX, GUIPosY + 50, GUIWidth, GUIHeight), "ARE YOU SURE YOU WANT TO \nGO BACK TO THE LEVEL SELECTION ?", GUIStyles.upperCenterTextStyle);
		
		// Draws the OK button
//		if(GUI.Button (new Rect (GUIPosX + (GUIWidth - buttonWidth) / 2, GUIPosY + GUIHeight * 0.7f + buttonHeight, buttonWidth, buttonHeight), OKButtonContent))
//			this.OkClicked();
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