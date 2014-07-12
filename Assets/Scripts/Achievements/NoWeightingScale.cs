using UnityEngine;
using System.Collections;

public class NoWeightingScale : MonoBehaviour {
	
	public int achievementNumber = 0;
	public GameObject door;
	public GameObject[] weightingScales;
	private bool achievementComplete = true;
	
	// Use this for initialization
	void Start () {
		foreach(GameObject scale in weightingScales) {
			scale.GetComponent<WeightScaleBehaviour>().PlatformsAppear += weightingScaleActivated;	
		}
		door.GetComponent<DoorReached>().FinishedLevel += levelEnd;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void weightingScaleActivated() {
		achievementComplete = false;
		Debug.Log("Balanca activada");
	}
	
	void levelEnd() {
		// TODO
		gameObject.GetComponent<LevelAchievements>().updateAchievement(achievementNumber, achievementComplete);
	}
}
