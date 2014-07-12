using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour
{
	public string levelName;
	public int levelNumber;
	public Texture2D levelIcon;
	private Vector3 convertedPos;
	private Vector3 gObjectSize;
	private float selectionScale;
	
	private bool showAchievements = false;
	
	// Use this for initialization
	void Start ()
	{
		convertedPos = gameObject.transform.position;
		convertedPos.x -= gameObject.renderer.bounds.extents.x;
		convertedPos.y -= gameObject.renderer.bounds.extents.y;
		
		convertedPos = Camera.main.WorldToScreenPoint(convertedPos);
		convertedPos.y = Screen.height - convertedPos.y;
		
//		Debug.Log("SIZE: " + gameObject.renderer.bounds.size);
		gObjectSize = gameObject.renderer.bounds.size * (Camera.main.orthographicSize + 1);
		
		selectionScale = 1f;
	}

	
	public void selectButton()
	{
		selectionScale = 1.2f;
	}
	
	public void deselectButton()
	{
		selectionScale = 1f;
	}
	
	public void execute()
	{
			Application.LoadLevel(levelNumber + Application.loadedLevel);
	}
	
	public void showAchievementGUI() {
		if (showAchievements) {
			execute ();
		} else {
			showAchievements = true;
		}
	}
	
	public void leaveAchievementGUI() {
		showAchievements = false;	
	}
	
	public void OnGUI ()
	{		
		if (!showAchievements) {
			GUI.Label(new Rect(convertedPos.x, convertedPos.y, 150, 30), this.levelName, GUIStyles.upperTextStyle);
			
			if(GUI.Button(new Rect(convertedPos.x, convertedPos.y - gObjectSize.y, gObjectSize.x * selectionScale, gObjectSize.y * selectionScale), levelIcon))
			{
				//execute();
			}
		} else {
			GUILevelSelectionAchievements.Instance.UpdateValues((int)convertedPos.x - 120, (int)convertedPos.y - 200, gameObject.GetComponent<LevelSelectionAchievementData>() as LevelSelectionAchievementData);
			GUILevelSelectionAchievements.Instance.Draw();	
		}
	}	
}
