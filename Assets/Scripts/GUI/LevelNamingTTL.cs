using UnityEngine;
using System.Collections;

public class LevelNamingTTL : MonoBehaviour
{

	public float labelTTL = 3.0f; //time to live
//	public float fadeTime = 1.0f;

	public void Start ()
	{
		Destroy (gameObject, labelTTL);
		
//		StartCoroutine(Fade.use.Alpha(renderer.material, Color.black, Color.white, 2.0f, EaseType.InOut));
		
//		yield WaitForSeconds(labelTTL);
//		Fade.use.Alpha(guiText.material, 1.0, 0.0, fadeTime);
		
//	}


//function Start () {
//	public void Start()
//	{
//	    yield Fade.use.Alpha(gameObject, 0.0, 1.0, 2.0, EaseType.In);
//	    yield WaitForSeconds(1.5);
//	    yield Fade.use.Alpha(title.guiTexture, 1.0, 0.0, 2.0, EaseType.Out);
//		Destroy(gameObject);
//	}
	}
}