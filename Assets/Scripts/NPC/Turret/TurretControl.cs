using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class TurretControl : MonoBehaviour
{	
	private AudioSource sound;
	private GameObject target;
	private ArrayList targets;
	private OTAnimatingSprite animator;
	public float damp = 5;
	
	public void Awake()
	{
		target = null;	
		targets = new ArrayList();	
		foreach (Transform child in transform) {
			if(child.name == "turretSound") {
				sound = child.gameObject.GetComponent<AudioSource>();
				break;
			}
		}
		sound.transform.Translate(new Vector3(0, 0, Camera.main.transform.position.z));
	}
	
	// Use this for initialization
	void Start ()
	{
		animator = this.GetComponent<OTAnimatingSprite> ();
	}
		
	public void Update ()
	{
		if (target != null) {
			animator.RotateTowards(target.transform.position);
			animator.rotation -= 90; //HACK para corrigir upVector
		}
		else {
			animator.rotation = 0;
		}
	}
	
	public void OnTriggerEnter (Collider col)
	{
//		if (col.gameObject.layer == "CloneCollision") { //"Clone") {
			//Debug.Log ("NEW POSSIBLE TARGET HAS ENTERED!");
			GameObject targetTemp = col.gameObject.transform.parent.gameObject;
			targets.Add (targetTemp);
			CloneAbilities ca = targetTemp.GetComponent<CloneAbilities> ();
			ca.OnDestroyEvent += this.TargetDied;
			//sound.Play();
			if (target == null) {			
				//Debug.Log ("NEW TARGET ACQUIRED!");
				selectNewTarget ();
//			}
		}
	}
	
	public void OnTriggerExit (Collider col)
	{
//		if (col.gameObject.tag == "Clone") {
			//Debug.Log ("A POSSIBLE TARGET HAS ESCAPED!");
		GameObject targetTemp = col.gameObject.transform.parent.gameObject;
			
			
			CloneAbilities colAbilities = targetTemp.GetComponent<CloneAbilities>();
		colAbilities.OnDestroyEvent -= TargetDied;
			if(colAbilities.cloneType == "EMO")
			{
				Debug.Log("EMO ESCAPED ON TURRET");
				(colAbilities as NEWEmoCloneAbilities).Ressurect();
			}
			
			targets.Remove (targetTemp);
			
			if (target.Equals (targetTemp))//col.gameObject))
				selectNewTarget ();
//		}
	}
	
	public void TargetDied (GameObject tclone)
	{
		Debug.Log ("POSSIBLE TARGET HAS DIED! " + tclone.name);	
		tclone.GetComponent<CloneAbilities> ().OnDestroyEvent -= TargetDied;
		targets.Remove (tclone);
		if (target.Equals (tclone)) {
			Debug.Log("TARGET CLONE DIED");
			target = null;
			selectNewTarget ();
		}
		//sound.Stop();
	}
	
	public void selectNewTarget ()
	{
		Debug.Log ("SELECT NEW TARGET!!");
		if (targets.Count != 0) {
			
			foreach(GameObject go in targets)
			{
				if(go.GetComponent<CloneAbilities>().getCloneType().Equals("emo", StringComparison.OrdinalIgnoreCase))
				{
					target = go;
					break;
				}
			}
			if(target == null)
			{   //means there is no EMO clone in the list
				Debug.Log("NEW TARGET IS NORMAL");
				target = (GameObject) targets[0];
				animator.PlayOnce("fire");
				animator.onAnimationFinish = this.KillClone;
			}
			else {
				//Means target is the emo clone!
				Debug.Log("NEW TARGET IS EMO");
				animator.PlayLoop("fire");
				target.GetComponent<NEWEmoCloneAbilities>().BeingShot();
			}

		} else {
			//Debug.Log ("NO TARGET IN SIGHT");
			Debug.Log("NO TARGETS IN SIGHT");
			animator.PlayLoop ("idle");
			target = null;
		}
	}
	
	public void KillClone(OTObject owner)
	{
		if(owner == animator) {
			Debug.Log("KILL CLONE");
			animator.onAnimationFinish = ((OTObject ownerObject) => {});
			target.GetComponent<CloneAbilities>().BeingShot();	
		}
	}
}