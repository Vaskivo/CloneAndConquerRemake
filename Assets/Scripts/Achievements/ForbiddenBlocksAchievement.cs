using UnityEngine;
using System.Collections;

public class ForbiddenBlocksAchievement : MonoBehaviour {
	
	public int achievementNumber = 0;
	public GameObject door;
	private bool achievementComplete = true;
	
	// Use this for initialization
	void Start () {
		door.GetComponent<DoorReached>().FinishedLevel += levelEnd;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void levelEnd() {
		gameObject.GetComponent<LevelAchievements>().updateAchievement(achievementNumber, achievementComplete);
		//Debug.Log("No "+cloneType+": "+achievementComplete);
	}
	
	public void achievementFailed() {
		achievementComplete = false;	
	}
}
