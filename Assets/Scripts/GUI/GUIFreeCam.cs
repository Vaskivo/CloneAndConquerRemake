using UnityEngine;
using System.Collections;

public class GUIFreeCam : IGUI
{

	private Texture2D crosshairTexture;
	private Texture triangleTexture;
	private Texture circleTexture;
	private Texture startTexture;
	private GUIContent resumeContent;
	private GUIContent restartContent;
	private GUIContent selectionContent;
	private Rect crossPosition;
	private Vector2 achievPosition;
	private LevelAchievements achievements;
	private Texture starFull;
	private Texture starEmpty;
	private IGUI secondaryGUI;
	private bool isTutor; //TODO: remove this hack..
	
	static GUIFreeCam ()
	{
		instance = new GUIFreeCam ();
	}
	
	public static GUIFreeCam Instance { get { return instance; } }

	private static GUIFreeCam instance;
	
	private GUIFreeCam ()
	{
		//initialize variables like sizes, positions, etc...
		crossPosition = new Rect (0, 0, Screen.width, Screen.height);
		crosshairTexture = Resources.Load ("crosshair") as Texture2D;
		
		startTexture = Resources.Load ("psbuttons/start") as Texture;
		circleTexture = Resources.Load ("psbuttons/circle") as Texture;
		triangleTexture = Resources.Load ("psbuttons/triangle") as Texture;
		
		resumeContent = new GUIContent (" Resume", startTexture);
		restartContent = new GUIContent (" Restart Level", triangleTexture);
		selectionContent = new GUIContent (" Level Selection", circleTexture);
		
		starFull = Resources.Load ("star_full") as Texture;
		starEmpty = Resources.Load ("star_empty") as Texture;
		
		achievements = (LevelAchievements)GameObject.Find ("GlobalScripts").GetComponent<LevelAchievements> ();
		achievPosition = new Vector2 (Screen.width * 0.55f, Screen.height * 0.8f);

		secondaryGUI = EmptyGUI.Instance;
	}
	
	public void Draw ()
	{
		GUI.DrawTexture (crossPosition, crosshairTexture);
		GUI.Label (new Rect (Screen.width / 2f - 150f, Screen.height * 0.1f, 300, 500), "Free Camera Mode", GUIStyles.upperCenterTextStyle);
		GUI.Label (new Rect (Screen.width / 20f + 10f, Screen.height * 0.8f, 300, 50), resumeContent, GUIStyles.leftTextStyle); //+10f.. don't know why this is different
		GUI.Label (new Rect (Screen.width / 20f, Screen.height * 0.85f, 300, 50), restartContent, GUIStyles.leftTextStyle);
		GUI.Label (new Rect (Screen.width / 20f, Screen.height * 0.92f, 300, 50), selectionContent, GUIStyles.leftTextStyle);
	


		if (!isTutor && achievements != null) {
			if (achievements.levelCompleted) {
				GUI.Label (new Rect (achievPosition.x, achievPosition.y, 45, 45), starFull, GUIStyles.achievementIconStyle);
			} else {
				GUI.Label (new Rect (achievPosition.x, achievPosition.y, 45, 45), starEmpty, GUIStyles.achievementIconStyle);
			}
			GUI.Label (new Rect (achievPosition.x + 50f, achievPosition.y + 5f, 900, 45), achievements.levelCompleteText, GUIStyles.leftTextStyle);
		
			if (achievements.achievement1Completed) {
				GUI.Label (new Rect (achievPosition.x, achievPosition.y + 50f, 45, 45), starFull, GUIStyles.achievementIconStyle);
			} else {
				GUI.Label (new Rect (achievPosition.x, achievPosition.y + 50f, 45, 45), starEmpty, GUIStyles.achievementIconStyle);
			}
			GUI.Label (new Rect (achievPosition.x + 50f, achievPosition.y + 55f, 900, 45), achievements.achievement1Text, GUIStyles.leftTextStyle);
		
			if (achievements.achievement2Completed) {
				GUI.Label (new Rect (achievPosition.x, achievPosition.y + 100f, 45, 45), starFull, GUIStyles.achievementIconStyle);
			} else {
				GUI.Label (new Rect (achievPosition.x, achievPosition.y + 100f, 45, 45), starEmpty, GUIStyles.achievementIconStyle);
			}
			GUI.Label (new Rect (achievPosition.x + 50f, achievPosition.y + 105f, 900, 45), achievements.achievement2Text, GUIStyles.leftTextStyle);
		}
		
		secondaryGUI.Draw ();
//		GUILevelSelectionAchievements.Instance.UpdateValues(Screen.width * 0.8f, Screen.height * 0.6f, new LevelSelectionAchievementData());
//		GUILevelSelectionAchievements.Instance.Draw();

		if (achievements == null) {
			Debug.Log ("NO ACHIEVEMENTS!");
			UpdateAchievements();
		}
	}
	
	public void UpdateAchievements ()
	{
		if (!isTutor)
			achievements = (LevelAchievements)GameObject.Find ("GlobalScripts").GetComponent<LevelAchievements> ();	
	}
	
	public void addConfirmationGUI (IGUI gui)
	{
		this.secondaryGUI = gui;	
	}

	public void activateTutorMode ()
	{
		this.isTutor = true;	
	}
	
	public void resetSecondaryGUI ()
	{
		secondaryGUI = EmptyGUI.Instance;	
	}
	
	public void XPressed ()
	{
	}
	
	public void OPressed ()
	{
	}
}
