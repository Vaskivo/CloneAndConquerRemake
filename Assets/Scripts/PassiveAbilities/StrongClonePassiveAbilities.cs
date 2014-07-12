using UnityEngine;
using System.Collections;

public class StrongClonePassiveAbilities : ClonePassiveAbilities
{
	
	NEWStrongCloneAnimation cloneanimation;
	
	public float throwForce = 10000;
	public float throwDuration = 1;
	public float throwAngle = 30;
	private bool isFighting;
	
	public override void Start ()
	{
//		this.isFighting = false;
//		this.gameObject.GetComponent<NEWStrongCloneAbilities>().StartedFighting += this.StartedFight;
//		this.cloneanimation = this.gameObject.GetComponent<NEWStrongCloneAnimation>();
	}
	
	public override void init()
	{
		this.isFighting = false;
		this.gameObject.GetComponent<NEWStrongCloneAbilities>().StartedFighting += this.StartedFight;
		this.cloneanimation = this.gameObject.GetComponent<NEWStrongCloneAnimation>();
	}
	
	public void StartedFight ()
	{
		this.isFighting = true;
	}
	
	public override void doStuff (GameObject target)
	{
		//Debug.Log("FIGHTING? "+ this.isFighting);
		if (this.enabled && !isFighting) 
		{
			Vector3 relativePosition = gameObject.transform.InverseTransformPoint(target.transform.position);
			if (relativePosition.y > -0.3f) {
				target.rigidbody.velocity = Vector3.zero;
				if(cloneanimation.isLeft)
					target.rigidbody.AddForce (Quaternion.AngleAxis (180f + throwAngle, Vector3.back) * (Vector3.right * throwForce));
				else target.rigidbody.AddForce (Quaternion.AngleAxis (-throwAngle, Vector3.back) * (Vector3.right * throwForce));
				GetComponent<CloneDialog>().AbilityTriggered();
			}
			
		}
	}

	//	public override void doStuff(GameObject other) {
//		if (!turnedOn && !isFighting) {
//			CloneBase otherComp = other.GetComponent<CloneBase>();
//			float otherTop = otherComp.topBoundary + other.transform.position.y;
//			if (otherTop >= gameObject.transform.position.y) {
//				other.gameObject.rigidbody.velocity = Vector3.zero;
//				if(cBase.isLeft) {
//					other.GetComponent<CloneBase>().strongThrow(throwForce, throwDuration, 180f - throwAngle);
//				} else {
//					other.GetComponent<CloneBase>().strongThrow(throwForce, throwDuration, throwAngle);
//				}
//			}
//		}
//	}
	
//	public void strongThrow(float throwforce, float duration, float angle) {
//		isStrongThrowed	= true;
//		strongThrowDuration = duration;
//		strongThrowStart = Time.realtimeSinceStartup;
//		gameObject.rigidbody.velocity = Vector3.zero;
//		gameObject.rigidbody.AddForce(Quaternion.AngleAxis(-angle, Vector3.back) * (Vector3.right * throwforce));
//	}

}
