using UnityEngine;
using System.Collections;

public class NoCloneTypeDetector : MonoBehaviour {
	
	public int achievementNumber = 0;
	public string cloneType;
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
		if (clone.GetComponent<CloneAbilities>().cloneType == cloneType) {
			achievementComplete = false;
			Debug.Log("Criaste clone proibido");
		}
	}
	
	void levelEnd() {
		// TODO
		gameObject.GetComponent<LevelAchievements>().updateAchievement(achievementNumber, achievementComplete);
		//Debug.Log("No "+cloneType+": "+achievementComplete);
	}
}
