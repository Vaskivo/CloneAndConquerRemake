using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using INIConfiguration;

public class LevelSelectionAchievementData : MonoBehaviour {
	
	public string sceneName = string.Empty;
	[HideInInspector] public string levelCompleteText = string.Empty;
	[HideInInspector] public string achievement1Text = string.Empty;
	[HideInInspector] public string achievement2Text = string.Empty;
	
	[HideInInspector] public bool levelComplete = false;
	[HideInInspector] public bool achievement1Complete = false;
	[HideInInspector] public bool achievement2Complete = false;
	
	INIFileHandler iniFile;
	
	// Use this for initialization
	void Start () {
		
//		iniFile = new INIFileHandler(".\\achievements.ini");
//		levelCompleteText = iniFile.IniReadValue(this.sceneName, "Achievement 1");
//		achievement1Text = iniFile.IniReadValue(this.sceneName, "Achievement 2");
//		achievement2Text = iniFile.IniReadValue(this.sceneName, "Achievement 3");

		if ("TinyLevel1".Equals(this.sceneName)) {
			levelCompleteText = "Level Finished";
			achievement1Text = "Don't use Weighting Scale";
			achievement2Text = "KLON3 doesn't step on Orangle Floor";
		}
		if ("TinyLevel2".Equals(this.sceneName)) {
			levelCompleteText = "Level Finished";
			achievement1Text = "No Wimp Clone";
			achievement2Text = "No Fighting";
		}
		if ("TinyLevel3".Equals(this.sceneName)) {
			levelCompleteText = "Level Finished";
			achievement1Text = "No Fat Clones";
			achievement2Text = "KUse Only the Wimp Clone";
		}
		
		Dictionary<string, bool > data = DataPersistence.Instance.achievements;
		if (data.ContainsKey(sceneName+"COMPLETE")) {
			levelComplete = data[sceneName+"COMPLETE"];
		}
		if (data.ContainsKey(sceneName+"ACH1")) {
			achievement1Complete = data[sceneName+"ACH1"];
		}
		if (data.ContainsKey(sceneName+"ACH2")) {
			achievement2Complete = data[sceneName+"ACH2"];
		}	
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}
