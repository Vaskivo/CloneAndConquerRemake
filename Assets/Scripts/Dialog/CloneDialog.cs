using UnityEngine;
using System.Collections;
using System;

public class CloneDialog : MonoBehaviour {

	public AudioClip[] BornTalk;
	public AudioClip[] CloneAbility;
	public AudioClip[] FatInteractionTalk;
	public AudioClip[] StrongInteractionTalk;
	public AudioClip[] EmoInteractionTalk;
	public AudioClip[] FatDeadTalk;
	public AudioClip[] StrongDeadTalk;
	public AudioClip[] EmoDeadTalk;
	public AudioClip[] SpikesInteractionTalk;
	public AudioClip[] TurretInteractionTalk;
	public AudioClip[] SecurityInteractionTalk;
	
	public string lastCloneDead = null;
	
	private System.Random rand;
	
	void Awake() {
		rand = new System.Random(Time.frameCount);	
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public virtual void CloneBorn() {
		if ( BornTalk.Length == 0) {
			return;	
		}
		
		int sound = rand.Next(BornTalk.Length);
		AudioSource.PlayClipAtPoint(BornTalk[sound], transform.position, 1f);
		
		//Debug.Log("NASCI - e sou " + gameObject.GetComponent<CloneAbilities>().cloneType);
	}
	
	public virtual void AbilityTriggered() {
		if ( CloneAbility.Length == 0) {
			return;	
		}
		
		int sound = rand.Next(CloneAbility.Length);
		AudioSource.PlayClipAtPoint(CloneAbility[sound], transform.position);
	}
	
	public virtual void CloneInteraction(GameObject other) {
		int sound;
		AudioClip[] tmp = null;
		switch (other.GetComponent<CloneAbilities>().cloneType) {
		case "FAT":
			tmp = FatInteractionTalk;
//			Debug.Log("BATI NUM GORDO! - e sou " + gameObject.GetComponent<CloneAbilities>().cloneType);
			break;
		case "STRONG":
			tmp = StrongInteractionTalk;
//			Debug.Log("BATI NUM FORTE! - e sou " + gameObject.GetComponent<CloneAbilities>().cloneType);
			break;
		case "EMO":
			tmp = EmoInteractionTalk;
//			Debug.Log("BATI NUM EMO! - e sou " + gameObject.GetComponent<CloneAbilities>().cloneType);
			break;
		}
		if (tmp.Length == 0) {
			return;	
		}		
		sound = rand.Next(tmp.Length);
		AudioSource.PlayClipAtPoint(tmp[sound], transform.position);
	}
	
	// when another clone dies
	public void CloneDead() {
		int sound;
		AudioClip[] tmp = null;
		switch (lastCloneDead) {
		case "FAT":
			tmp = FatDeadTalk;
//			Debug.Log("MORREU UM GORDO! - e sou " + gameObject.GetComponent<CloneAbilities>().cloneType);
			break;
		case "STRONG":
			tmp = StrongDeadTalk;
//			Debug.Log("MORREU UM FORTE! - e sou " + gameObject.GetComponent<CloneAbilities>().cloneType);
			break;
		case "EMO":
			tmp = EmoDeadTalk;
//			Debug.Log("MORREU UM EMO! - e sou " + gameObject.GetComponent<CloneAbilities>().cloneType);
			break;
		}
		if (tmp.Length == 0) {
			return;	
		}		
		sound = rand.Next(tmp.Length);
		AudioSource.PlayClipAtPoint(tmp[sound], transform.position);
	}
	
	public void HazardInteraction(string hazard) {
		int sound;
		AudioClip[] tmp = null;
		switch (hazard) {
		case "SPIKES":
			tmp = SpikesInteractionTalk;
//			Debug.Log("PICOS! - e sou " + gameObject.GetComponent<CloneAbilities>().cloneType);
			break;
		case "SECURITY":
			tmp = SecurityInteractionTalk;
//			Debug.Log("GUARDA! - e sou " + gameObject.GetComponent<CloneAbilities>().cloneType);
			break;
		case "TURRET":
			tmp = TurretInteractionTalk;
//			Debug.Log("TURRET! - e sou " + gameObject.GetComponent<CloneAbilities>().cloneType);
			break;
		}
		if (tmp.Length == 0) {
			return;	
		}		
		sound = rand.Next(tmp.Length);
		AudioSource.PlayClipAtPoint(tmp[sound], transform.position);
	}
	
	// just to be safe
	void OnDestroy() {
		if(!Application.isLoadingLevel)
		{
			//Camera.main.GetComponent<CameraFollowMainPlayer>().StoppedMovingAfterDeath -= CloneDead;
		}
	}
}
