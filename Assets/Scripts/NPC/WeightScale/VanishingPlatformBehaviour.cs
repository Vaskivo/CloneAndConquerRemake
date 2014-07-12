using UnityEngine;
using System.Collections;

public class VanishingPlatformBehaviour : MonoBehaviour {
	
	public LayerMask vanishedLayer;
	public LayerMask opaqueLayer;
	public float transparencyOnVanish = 0.2f;
	
	public GameObject weightScale;
	private OTSprite sprite;
	
	// Use this for initialization
	void Start () {
		sprite = gameObject.GetComponent<OTSprite>();
		WeightScaleBehaviour comp = weightScale.GetComponent<WeightScaleBehaviour>();
		comp.PlatformsAppear += this.Appear;
		comp.PlatformsVanish += this.Vanish;
		Vanish();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	void Vanish() {
//		sprite.transparent = true;
//		sprite.renderer.material.SetColor("_Color", new Color(.1f,.1f,.1f, .4f));
//		//sprite.renderer.material.SetColor("_TintColor", new Color(.1f, .1f, .4f));
//		//sprite.alpha = transparencyOnVanish;
		gameObject.layer = LayerMask.NameToLayer("VanishingPlatforms");
		sprite.frameIndex = 1; // hack :(
	}
	
	void Appear() {
//	//	sprite.alpha = 1f;
//		sprite.renderer.material.SetColor("_Color", new Color(.1f,.1f,.1f, 1f));
		gameObject.layer = LayerMask.NameToLayer("Blocks");
		sprite.frameIndex = 0; // hack :'(
	}
}
