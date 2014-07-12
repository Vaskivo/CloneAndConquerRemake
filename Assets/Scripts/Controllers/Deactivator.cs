//using UnityEngine;
//using System.Collections;
//
//public class Deactivator : MonoBehaviour {
//
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//	}
//	
//	public void activate() {
//		Component comp;
//		
//		// activate movement
//		if (comp = gameObject.GetComponent<CloneBasicMovement>()) {
//			((CloneBasicMovement)comp).activate();
//		}
//		
//		// activate main clone abilities
//		if (comp = gameObject.GetComponent<NEWMainCloneAbilities>()) {
//			((NEWMainCloneAbilities)comp).activate();	
//		}
//		
//		if (comp = gameObject.GetComponent<FatCloneAbilities>()) {
//			((FatCloneAbilities)comp).activate();	
//		}
//		
//		if (comp = gameObject.GetComponent<StrongCloneAbilities>()) {
//			((StrongCloneAbilities)comp).activate();
//		}
//	}
//	
//	public void deactivate() {
//		Component comp;
//		// activate movement
//		if (comp = gameObject.GetComponent<CloneBasicMovement>()) {
//			((CloneBasicMovement)comp).deactivate();
//		}
//		
//		// activate main clone abilities
//		if (comp = gameObject.GetComponent("MainCloneAbilities")) {
//			((NEWMainCloneAbilities)comp).deactivate();	
//		}
//		
//		if (comp = gameObject.GetComponent<FatCloneAbilities>()) {
//			((FatCloneAbilities)comp).deactivate();	
//		}
//		
//		if (comp = gameObject.GetComponent<StrongCloneAbilities>()) {
//			((StrongCloneAbilities)comp).deactivate();	
//		}
//	}
//}
