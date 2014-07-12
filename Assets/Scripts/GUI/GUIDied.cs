using UnityEngine;
using System.Collections;
using System;

public class GUIDied : IGUI
{
	public event Action OkClicked;
	public event Action CancelClicked;
	public event Action ContinueClicked;

	private int totalButtons;
	private int GUIWidth;						// Defines the GUI background width
	private int GUIHeight; 						// Defines the GUI background height
	private int GUIPosX; // Defines the GUI position on the X axis
	private int GUIPosY; 	// Defines the GUI position on the Y axis
	
	private int buttonWidth;
	private int buttonHeight;
	private int widthAvailableForEachButton;
	private int widthLeftFromAvailable;
	
	private Texture crossTexture;
	private Texture circleTexture;
	private Texture triangleTexture;
	
	private GUIContent OKButtonContent;
	private GUIContent CancelButtonContent;
	private GUIContent ContinueButtonContent;
	
	private Texture starFull;
	private Texture starEmpty;
	
	private LevelAchievements achievements;
	
	
	static GUIDied ()
	{
		instance = new GUIDied ();
	}
	
	public static GUIDied Instance { get { return instance; } }

	private static GUIDied instance;
	
	private GUIDied ()
	{
		//	backgroundBoxStyle.normal.background = Resources.Load ("Box_background") as Texture2D;
		totalButtons = 3;
		GUIWidth = 800; 						
		GUIHeight = 500; 						
		GUIPosX = (Screen.width - GUIWidth) / 2; 	
		GUIPosY = (Screen.height - GUIHeight) / 2; 	
		buttonWidth = 200;
		buttonHeight = 50;
		
		widthAvailableForEachButton = (int) (GUIWidth / totalButtons);
		widthLeftFromAvailable = (int) (widthAvailableForEachButton - buttonWidth);
		//First Button starts at: GUIPosX + startXofButton
		//Last Button starts at: GUIPosX + GUIWidth - buttonWidth - startXofButton
		//Middle Buttons start at: GUIPosX + (N * widthForEachButton) + (startXofButton / 2)
		
		crossTexture = Resources.Load ("psbuttons/cross") as Texture;
		circleTexture = Resources.Load ("psbuttons/circle") as Texture;
		triangleTexture = Resources.Load ("psbuttons/triangle") as Texture;
		
		OKButtonContent = new GUIContent (" RELOAD", crossTexture);		
		CancelButtonContent = new GUIContent (" LEVEL SELECTION", circleTexture);
		ContinueButtonContent = new GUIContent (" CONTINUE", triangleTexture);
		
		starFull = Resources.Load ("star_full") as Texture;
		starEmpty = Resources.Load ("star_empty") as Texture;
	}
	
	public void Draw ()
	{
		Color backgroundColor = new Color (0.4f, 0.4f, 0.4f, 1.0f); // Light Grey
		
		// Draws the box background
		GUI.backgroundColor = backgroundColor;
		GUI.Box (new Rect (GUIPosX, GUIPosY, GUIWidth, GUIHeight), string.Empty, GUIStyles.backgroundBoxStyle);
		
		// Draws the message
		GUI.Label (new Rect (GUIPosX, GUIPosY + 50, GUIWidth, GUIHeight), "YOU HAVE DIED!", GUIStyles.upperCenterTextStyle);
		
		LevelAchievements achievements = (LevelAchievements)GameObject.Find("GlobalScripts").GetComponent<LevelAchievements>();
		
		if (achievements != null) {
			if (achievements.levelCompleted) {
					GUI.Label (new Rect (200, 230, 45, 45), starFull, GUIStyles.achievementIconStyle);
			} else {
					GUI.Label (new Rect (200, 230, 45, 45), starEmpty, GUIStyles.achievementIconStyle);
			}
			GUI.Label (new Rect (250, 245, 900, 45), achievements.levelCompleteText, GUIStyles.leftTextStyle);

			if (achievements.achievement1Completed) {
					GUI.Label (new Rect (200, 300, 45, 45), starFull, GUIStyles.achievementIconStyle);
			} else {
					GUI.Label (new Rect (200, 300, 45, 45), starEmpty, GUIStyles.achievementIconStyle);
			}
			GUI.Label (new Rect (250, 315, 900, 45), achievements.achievement1Text, GUIStyles.leftTextStyle);

			if (achievements.achievement2Completed) {
					GUI.Label (new Rect (200, 370, 45, 45), starFull, GUIStyles.achievementIconStyle);
			} else {
					GUI.Label (new Rect (200, 370, 45, 45), starEmpty, GUIStyles.achievementIconStyle);
			}
			GUI.Label (new Rect (250, 385, 900, 45), achievements.achievement2Text, GUIStyles.leftTextStyle);
		}

		#region BUTTONS
		if (GUI.Button (new Rect (GUIPosX + widthLeftFromAvailable, GUIPosY + GUIHeight * 3 / 4 + buttonHeight / 2, buttonWidth, buttonHeight), OKButtonContent))
			this.OkClicked ();
		if (GUI.Button (new Rect (GUIPosX + widthAvailableForEachButton + (widthLeftFromAvailable / 2), GUIPosY + GUIHeight * 3 / 4 + buttonHeight / 2, buttonWidth, buttonHeight), ContinueButtonContent))
			this.ContinueClicked ();
		if (GUI.Button (new Rect (GUIPosX + GUIWidth - buttonWidth - widthLeftFromAvailable, GUIPosY + GUIHeight * 3 / 4 + buttonHeight / 2, buttonWidth, buttonHeight), CancelButtonContent))
			this.CancelClicked ();
		#endregion
		//First Button starts at: GUIPosX + startXofButton
		//Last Button starts at: GUIPosX + GUIWidth - buttonWidth - startXofButton
		//Middle Buttons start at: GUIPosX + (N * widthForEachButton) + (startXofButton / 2)
	}
	
	public void UpdateAchievements ()
	{
		achievements = (LevelAchievements)GameObject.Find ("GlobalScripts").GetComponent<LevelAchievements> ();	
	}

	public void XPressed ()
	{
		this.OkClicked ();
	}
	
	public void OPressed ()
	{
		this.CancelClicked ();	
	}
	
	//	public void TrianglePressed()
//	{
//		this.ContinuePressed();	
//	}
}