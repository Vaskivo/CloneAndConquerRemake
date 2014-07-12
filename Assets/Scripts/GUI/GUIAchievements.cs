using UnityEngine;
using System.Collections;
using System;

public class GUIAchievements : IGUI
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
	private Texture starFull;
	private Texture starEmpty;
	private LevelAchievements achievements;
	
	static GUIAchievements ()
	{
		instance = new GUIAchievements ();
	}
	
	public static GUIAchievements Instance { get { return instance; } }

	private static GUIAchievements instance;
	
	private GUIAchievements ()
	{
		//	backgroundBoxStyle.normal.background = Resources.Load ("Box_background") as Texture2D;
		
		GUIWidth = 800; 						
		GUIHeight = 500; 						
		GUIPosX = (Screen.width - GUIWidth) / 2; 	
		GUIPosY = (Screen.height - GUIHeight) / 2; 	
		buttonWidth = 200;
		buttonHeight = 50;
		
		crossTexture = Resources.Load ("psbuttons/cross") as Texture;
		circleTexture = Resources.Load ("psbuttons/circle") as Texture;
		
		OKButtonContent = new GUIContent (" RELOAD LEVEL", crossTexture);		
		CancelButtonContent = new GUIContent (" LEVEL SELECTION", circleTexture);
		
		starFull = Resources.Load ("star_full") as Texture;
		starEmpty = Resources.Load ("star_empty") as Texture;
		
		achievements = (LevelAchievements)GameObject.Find ("GlobalScripts").GetComponent<LevelAchievements> ();
	}
	
	public void Draw ()
	{
		Color backgroundColor = new Color (0.4f, 0.4f, 0.4f, 1.0f); // Light Grey
		
		// Draws the box background
		GUI.backgroundColor = backgroundColor;
		GUI.Box (new Rect (GUIPosX, GUIPosY, GUIWidth, GUIHeight), "", GUIStyles.backgroundBoxStyle);
		
		// Draws the message
		GUI.Label (new Rect (GUIPosX, GUIPosY + 20, GUIWidth, GUIHeight), "CONGRATS!!\n\n\n YOU'VE COMPLETED THIS LEVEL!", GUIStyles.upperCenterTextStyle);//GUIStyles.upperTextStyle);
		
		
//		LevelAchievements achievements = GameObject.Find("GlobalScripts").GetComponent<LevelAchievements>() as LevelAchievements;
		
		if (achievements != null) {
			if (achievements.levelCompleted) {
				GUI.Label (new Rect (200, 250, 45, 45), starFull, GUIStyles.achievementIconStyle);
			} else {
				GUI.Label (new Rect (200, 250, 45, 45), starEmpty, GUIStyles.achievementIconStyle);
			}
			GUI.Label (new Rect (250, 265, 900, 45), achievements.levelCompleteText, GUIStyles.leftTextStyle);
			
			if (achievements.achievement1Completed) {
				GUI.Label (new Rect (200, 320, 45, 45), starFull, GUIStyles.achievementIconStyle);
			} else {
				GUI.Label (new Rect (200, 320, 45, 45), starEmpty, GUIStyles.achievementIconStyle);
			}
			GUI.Label (new Rect (250, 335, 900, 45), achievements.achievement1Text, GUIStyles.leftTextStyle);
			
			if (achievements.achievement2Completed) {
				GUI.Label (new Rect (200, 390, 45, 45), starFull, GUIStyles.achievementIconStyle);
			} else {
				GUI.Label (new Rect (200, 390, 45, 45), starEmpty, GUIStyles.achievementIconStyle);
			}
			GUI.Label (new Rect (250, 405, 900, 45), achievements.achievement2Text, GUIStyles.leftTextStyle);
		}
		
		// Draws the OK button
//		if(GUI.Button (new Rect (GUIPosX + (GUIWidth - buttonWidth) / 2, GUIPosY + GUIHeight * 3 / 4 + buttonHeight / 2, buttonWidth, buttonHeight), OKButtonContent))
//			this.OkClicked ();
		#region BUTTONS
		if (GUI.Button (new Rect (GUIPosX + 100, GUIPosY + GUIHeight * 3 / 4 + buttonHeight / 2, buttonWidth, buttonHeight), OKButtonContent))
			this.OkClicked ();
		if (GUI.Button (new Rect (GUIPosX + GUIWidth - buttonWidth - 100, GUIPosY + GUIHeight * 3 / 4 + buttonHeight / 2, buttonWidth, buttonHeight), CancelButtonContent))
			this.CancelClicked ();
		#endregion
	}
	
	public void UpdateAchievements ()
	{
		achievements = (LevelAchievements)GameObject.Find ("GlobalScripts").GetComponent<LevelAchievements> ();	
	}
	
	public void XPressed ()
	{
		this.OkClicked ();
		//throw new System.NotImplementedException ();
	}
	
	public void OPressed ()
	{
		this.CancelClicked ();
	}
}