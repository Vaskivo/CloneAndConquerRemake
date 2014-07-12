using UnityEngine;
using System.Collections;

public class ForbiddenBlockBehaviour : MonoBehaviour {

	ForbiddenBlocksAchievement achievement = null;
	
	// Use this for initialization
	void Start () {
		achievement = GameObject.Find("GlobalScripts").GetComponent<ForbiddenBlocksAchievement>() as ForbiddenBlocksAchievement;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collider) {
		if( collider.gameObject.tag == "Clone") {
			if(collider.gameObject.GetComponent<CloneAbilities>().cloneType == "MAIN") {
				achievement.achievementFailed();	
			}
		}
	}
}
