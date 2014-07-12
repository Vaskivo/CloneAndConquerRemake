using UnityEngine;
using System.Collections;

public static class GUIStyles 
{
	public static GUIStyle upperTextStyle;
	public static GUIStyle centerTextStyle;
	public static GUIStyle rightTextStyle;
	public static GUIStyle leftTextStyle;
	public static GUIStyle leftSmallTextStyle;
	public static GUIStyle backgroundBoxStyle;
	public static GUIStyle sectionBoxStyle;
	public static GUIStyle backgroundBarStyle;
	public static GUIStyle progressBarStyle;
	public static GUIStyle bigTextFieldStyle;
	
	public static GUIStyle clonesDisplayStyle;
	public static GUIStyle clonesDisplaySelectedStyle;
	public static GUIStyle laserTextStyle;
	public static GUIStyle upperCenterTextStyle;
	public static GUIStyle achievementIconStyle;
	
	static GUIStyles()
	{
		int displayFontSize = 20;
		
		upperTextStyle = new GUIStyle();
		upperTextStyle.normal.textColor = Color.white;
		upperTextStyle.font = Resources.Load("Fonts/Tahoma") as Font;
		upperTextStyle.fontSize = displayFontSize;
		upperTextStyle.fontStyle = FontStyle.Normal;
		upperTextStyle.alignment = TextAnchor.UpperCenter;
		upperTextStyle.stretchWidth = true;
		upperTextStyle.wordWrap = true;
		
		upperCenterTextStyle = new GUIStyle();
		upperCenterTextStyle.normal.textColor = Color.white;
		upperCenterTextStyle.font = Resources.Load("Fonts/LASER4") as Font;
		upperCenterTextStyle.fontSize = 16;
		upperCenterTextStyle.fontStyle = FontStyle.Normal;
		upperCenterTextStyle.alignment = TextAnchor.UpperCenter;
		upperCenterTextStyle.contentOffset = Vector2.zero;
		upperCenterTextStyle.stretchWidth = true;
		upperCenterTextStyle.wordWrap = true;
		
		centerTextStyle = new GUIStyle();
		centerTextStyle.normal.textColor = Color.white;
		centerTextStyle.font = Resources.Load("Fonts/LASER4") as Font;
		centerTextStyle.fontSize = 16;
		centerTextStyle.fontStyle = FontStyle.Normal;
		centerTextStyle.alignment = TextAnchor.MiddleCenter;
		centerTextStyle.contentOffset = Vector2.zero;
		centerTextStyle.stretchWidth = true;
		centerTextStyle.wordWrap = true;

		rightTextStyle = new GUIStyle();
		rightTextStyle.normal.textColor = Color.white;
		rightTextStyle.font = Resources.Load("Fonts/Tahoma") as Font;
		rightTextStyle.fontSize = displayFontSize;
		rightTextStyle.fontStyle = FontStyle.Normal;
		rightTextStyle.alignment = TextAnchor.UpperRight;
		rightTextStyle.stretchWidth = true;
		rightTextStyle.wordWrap = true;

		leftTextStyle = new GUIStyle();
		leftTextStyle.normal.textColor = Color.white;
		leftTextStyle.font = Resources.Load("Fonts/Tahoma") as Font;
		leftTextStyle.fontSize = 24;
		leftTextStyle.fontStyle = FontStyle.Normal;
		leftTextStyle.alignment = TextAnchor.UpperLeft;
		leftTextStyle.stretchWidth = true;
		leftTextStyle.wordWrap = true;
		leftTextStyle.imagePosition = ImagePosition.ImageLeft;

		leftSmallTextStyle = new GUIStyle();
		leftSmallTextStyle.normal.textColor = Color.white;
		leftSmallTextStyle.font = Resources.Load("Fonts/Tahoma") as Font;
		leftSmallTextStyle.fontSize = 16;
		leftSmallTextStyle.fontStyle = FontStyle.Bold;
		leftSmallTextStyle.alignment = TextAnchor.UpperLeft;
		leftSmallTextStyle.stretchWidth = true;
		leftSmallTextStyle.wordWrap = true;
		
		laserTextStyle = new GUIStyle(GUI.skin.box);
		laserTextStyle.normal.textColor = Color.white;
		laserTextStyle.font = Resources.Load("Fonts/LASER4") as Font;
		laserTextStyle.fontSize = displayFontSize;
		laserTextStyle.fontStyle = FontStyle.Normal;
		laserTextStyle.alignment = TextAnchor.MiddleCenter;
		laserTextStyle.stretchWidth = true;
		laserTextStyle.wordWrap = true;
		
//		leftTextStyle = new GUIStyle(GUI.skin.box);
//		laserTextStyle.normal.textColor = Color.white;
//		laserTextStyle.font = Resources.Load("Fonts/LASER4") as Font;
//		laserTextStyle.fontSize = displayFontSize;
//		laserTextStyle.fontStyle = FontStyle.Normal;
//		laserTextStyle.alignment = TextAnchor.MiddleLeft;
//		laserTextStyle.stretchWidth = true;
//		laserTextStyle.wordWrap = true;
		
		backgroundBoxStyle = new GUIStyle();
		backgroundBoxStyle.normal.background = Resources.Load("Box_background") as Texture2D;
		
		clonesDisplayStyle = new GUIStyle(GUI.skin.box);
		
		clonesDisplaySelectedStyle = new GUIStyle();
		clonesDisplaySelectedStyle.normal.background = Resources.Load("selected_background") as Texture2D;
		clonesDisplaySelectedStyle.alignment = TextAnchor.MiddleCenter;
		
		achievementIconStyle = new GUIStyle();
		achievementIconStyle.alignment = TextAnchor.MiddleCenter;
	
	}
}
