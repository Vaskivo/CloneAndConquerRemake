using UnityEngine;
using System.Collections;
using System;

public class DoorReached : MonoBehaviour {
	
	public event Action FinishedLevel;
	

	public void OnTriggerEnter(Collider col)
	{	
		if(col.gameObject.Equals(CloneManager.Instance.mainClone))
		{
			//Debug.Log("ACABEI O NIVEL !!");
			this.FinishedLevel();	
		}
	}
}
