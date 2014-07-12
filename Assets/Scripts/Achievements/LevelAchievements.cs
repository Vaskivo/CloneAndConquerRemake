using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using INIConfiguration;

public class LevelAchievements : MonoBehaviour {
	
	public GameObject door;
	[HideInInspector] public string levelCompleteText = string.Empty;
	[HideInInspector] public string achievement1Text = string.Empty;
	[HideInInspector] public string achievement2Text = string.Empty;
	
	[HideInInspector] public bool levelCompleted = false;
	[HideInInspector] public bool achievement1Completed = false;
	[HideInInspector] public bool achievement2Completed = false;
	
	INIFileHandler iniFile;
	
	// Use this for initialization
	void Start () {
		
//        iniFile = new INIFileHandler(".\\achievements.ini");
//		levelCompleteText = iniFile.IniReadValue(Application.loadedLevelName, "Achievement 1");
//		achievement1Text = iniFile.IniReadValue(Application.loadedLevelName, "Achievement 2");
//		achievement2Text = iniFile.IniReadValue(Application.loadedLevelName, "Achievement 3");

		if ("TinyLevel1".Equals(Application.loadedLevelName)) {
			levelCompleteText = "Level Finished";
			achievement1Text = "Don't use Weighting Scale";
			achievement2Text = "KLON3 doesn't step on Orangle Floor";
		}
		if ("TinyLevel2".Equals(Application.loadedLevelName)) {
			levelCompleteText = "Level Finished";
			achievement1Text = "No Wimp Clone";
			achievement2Text = "No Fighting";
		}
		if ("TinyLevel3".Equals(Application.loadedLevelName)) {
			levelCompleteText = "Level Finished";
			achievement1Text = "No Fat Clones";
			achievement2Text = "KUse Only the Wimp Clone";
		}



		
		Dictionary<string, bool > data = DataPersistence.Instance.achievements;
		if (data.ContainsKey(Application.loadedLevelName+"COMPLETE")) {
			levelCompleted = data[Application.loadedLevelName+"COMPLETE"];
		}
		if (data.ContainsKey(Application.loadedLevelName+"ACH1")) {
			achievement1Completed = data[Application.loadedLevelName+"ACH1"];
		}
		if (data.ContainsKey(Application.loadedLevelName+"ACH2")) {
			achievement2Completed = data[Application.loadedLevelName+"ACH2"];
		}
		door.GetComponent<DoorReached>().FinishedLevel += levelEndeded;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void levelEndeded() {
		levelCompleted = true;
	}
	
	public void updateAchievement(int number, bool state) {
		switch (number) {
		case 1:
			achievement1Completed = state ? state : achievement1Completed;
			break;
		case 2:
			achievement2Completed = state ? state : achievement2Completed;
			break;
		}
	}
	
	void OnDestroy() {
		Dictionary<string, bool> data = DataPersistence.Instance.achievements;
		if (data.ContainsKey(Application.loadedLevelName+"COMPLETE")) {
			data[Application.loadedLevelName+"COMPLETE"] = levelCompleted;
		} else {
			data.Add(Application.loadedLevelName+"COMPLETE", levelCompleted);
		}
		if (data.ContainsKey(Application.loadedLevelName+"ACH1")) {
			data[Application.loadedLevelName+"ACH1"] = achievement1Completed;
		} else {
			data.Add(Application.loadedLevelName+"ACH1", achievement1Completed);
		}
		if (data.ContainsKey(Application.loadedLevelName+"ACH2")) {
			data[Application.loadedLevelName+"ACH2"] = achievement2Completed;
		} else {
			data.Add(Application.loadedLevelName+"ACH2", achievement2Completed);
		}
		
			
	}
}
