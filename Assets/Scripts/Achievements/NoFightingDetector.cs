using UnityEngine;
using System.Collections;

public class NoFightingDetector : MonoBehaviour {
	
	public int achievementNumber = 0;
	public GameObject door;
	private bool achievementComplete = true;
	
	// Use this for initialization
	void Start () {
		CloneManager.Instance.CloneCreated += cloneCreated;
		door.GetComponent<DoorReached>().FinishedLevel += levelEnd;
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	void cloneCreated(GameObject clone) {
		if (clone.GetComponent<CloneAbilities>().cloneType == "STRONG") {
			clone.GetComponent<NEWStrongCloneAbilities>().StartedFighting += fightStarted;
		}
	}
	
	void fightStarted() {
		achievementComplete = false;
		Debug.Log("There was a fight");
	}
	
	void levelEnd() {
		// TODO
		gameObject.GetComponent<LevelAchievements>().updateAchievement(achievementNumber, achievementComplete);
	}
}
