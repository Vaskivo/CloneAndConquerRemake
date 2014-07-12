using UnityEngine;
using System.Collections;
using System;

public class GUILevelSelectionAchievements : IGUI {
	
	public event Action OkClicked;

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
	
	private LevelSelectionAchievementData data = null;
	
	static GUILevelSelectionAchievements ()
	{
		instance = new GUILevelSelectionAchievements ();
	}
	
	public static GUILevelSelectionAchievements Instance { get { return instance; } }

	private static GUILevelSelectionAchievements instance;
	
	private GUILevelSelectionAchievements ()
	{
		//	backgroundBoxStyle.normal.background = Resources.Load ("Box_background") as Texture2D;
		
		GUIWidth = 400; 						
		GUIHeight = 300; 						
		GUIPosX = (Screen.width - GUIWidth) / 2; 	
		GUIPosY = (Screen.height - GUIHeight) / 2; 	
		buttonWidth = 200;
		buttonHeight = 30;
		
		//initialize variables like sizes, positions, etc...	
		crossTexture = Resources.Load("psbuttons/cross") as Texture;
		circleTexture = Resources.Load("psbuttons/circle") as Texture;
		OKButtonContent = new GUIContent(" PLAY", crossTexture);		
		CancelButtonContent = new GUIContent(" BACK", circleTexture);
		starFull = Resources.Load("star_full") as Texture;
		starEmpty = Resources.Load("star_empty") as Texture;
	}
	
	public void Draw() {
		Color backgroundColor = new Color (0.4f, 0.4f, 0.4f, 1.0f); // Light Grey
		
		// Draws the box background
		GUI.backgroundColor = backgroundColor;
		GUI.Box (new Rect (GUIPosX, GUIPosY, GUIWidth, GUIHeight), "", GUIStyles.backgroundBoxStyle);
		
		GUI.Label(new Rect (GUIPosX + GUIWidth / 2f - 150, GUIPosY + 10, 300,45), "ACHIEVEMENTS", GUIStyles.centerTextStyle);
		
		if(data.levelComplete) {
			GUI.Label(new Rect(GUIPosX + 25,GUIPosY + 50, 45,45), starFull, GUIStyles.achievementIconStyle);
		} else {
			GUI.Label(new Rect(GUIPosX + 25,GUIPosY + 50, 45,45), starEmpty, GUIStyles.achievementIconStyle);
		}
		GUI.Label(new Rect(GUIPosX + 75, GUIPosY + 65, 900, 45), data.levelCompleteText, GUIStyles.leftSmallTextStyle);
		
		if(data.achievement1Complete) {
			GUI.Label(new Rect(GUIPosX + 25,GUIPosY + 100, 45,45), starFull, GUIStyles.achievementIconStyle);
		} else {
			GUI.Label(new Rect(GUIPosX + 25,GUIPosY + 100, 45,45), starEmpty, GUIStyles.achievementIconStyle);
		}
		GUI.Label(new Rect(GUIPosX + 75, GUIPosY + 115, 900, 45), data.achievement1Text, GUIStyles.leftSmallTextStyle);
		
		if(data.achievement2Complete) {
			GUI.Label(new Rect(GUIPosX + 25,GUIPosY + 150, 45,45), starFull, GUIStyles.achievementIconStyle);
		} else {
			GUI.Label(new Rect(GUIPosX + 25,GUIPosY + 150, 45,45), starEmpty, GUIStyles.achievementIconStyle);
		}
		GUI.Label(new Rect(GUIPosX + 75, GUIPosY + 165, 900, 45), data.achievement2Text, GUIStyles.leftSmallTextStyle);
		
		GUI.Button (new Rect (GUIPosX + 25, GUIPosY + GUIHeight * 3 / 4 + 30 / 2, 150, 30), OKButtonContent);
		GUI.Button (new Rect (GUIPosX + GUIWidth - buttonWidth - 25, GUIPosY + GUIHeight * 3 / 4 + 30 / 2, 150, 30), CancelButtonContent);
		
	}
	
	public void XPressed ()
	{
		this.OkClicked();
	}
	
	public void UpdateValues(int xPosition, int yPosition, LevelSelectionAchievementData achievementData) {
		GUIPosX = xPosition;
		GUIPosY = yPosition;
		data = achievementData;
	}
	
	public void OPressed () {}
}
