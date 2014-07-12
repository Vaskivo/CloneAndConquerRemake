using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIDisplay : IGUI
{
	private float widthOffset;
	private LinkedListNode<GameObject> temp;
	private GUIStyle displayStyle;
	
//	private Texture FatIcon;
//	private Texture StrongIcon;
//	private Texture EmoIcon;
//	
//	private GUIContent FatContent;
//	private GUIContent StrongContent;
//	private GUIContent EmoContent;
	
	static GUIDisplay()
	{
		instance = new GUIDisplay();
	}
	
	public static GUIDisplay Instance {get {return instance;}}
	private static GUIDisplay instance;	
	
	private GUIDisplay() 
	{
		//initialize variables like sizes, positions, etc...
//		FatIcon = Resources.Load("gordo _icon") as Texture;
//		StrongIcon = Resources.Load("forte_icon") as Texture;
//		EmoIcon = Resources.Load("emo_icon") as Texture;
//		
//		FatContent = new GUIContent("x" + CloneManager.Instance.fatCloneCount.ToString(), FatIcon);
//		StrongContent = new GUIContent("x" + CloneManager.Instance.strongCloneCount.ToString(), StrongIcon);
//		EmoContent = new GUIContent("x" + CloneManager.Instance.emoCloneCount.ToString(), EmoIcon);	
	}
	
	
	//DRAWS GUI ON DEMAND!
	public void Draw() 
	{
//		//-- !! NEW GUI !! --\\
//		if(CloneManager.Instance.fatCloneCount > 0)
//		{
//			//make guilabel
//			FatContent.text = "x" + CloneManager.Instance.fatCloneCount.ToString();
//			GUI.Label (new Rect (Screen.width / 20f, Screen.height * 0.1f, 1000, 50), FatContent, GUIStyles.leftTextStyle);
//		}
//		if(CloneManager.Instance.strongCloneCount > 0)
//		{
//			StrongContent.text = "x" + CloneManager.Instance.strongCloneCount.ToString();
//			GUI.Label (new Rect (Screen.width / 20f, Screen.height * 0.2f, 300, 50), StrongContent, GUIStyles.leftTextStyle);
//		}
//		if(CloneManager.Instance.emoCloneCount > 0)
//		{
//			EmoContent.text = "x" + CloneManager.Instance.emoCloneCount.ToString();
//			GUI.Label (new Rect (Screen.width / 20f, Screen.height * 0.3f, 1000, 50), EmoContent, GUIStyles.leftTextStyle);
//		}
		
		
		//-- !! OLD GUI !! --\\
		int nClones = CloneManager.Instance.clones.Count;
				
		temp = CloneManager.Instance.clones.First;
		widthOffset = Screen.width / nClones;
		
		for( int i = 0; i != nClones; ++i)
		{
			displayStyle = GUIStyles.clonesDisplayStyle;
			if(temp.Value.Equals(CloneManager.Instance.activeClone.Value))
			{
				displayStyle = GUIStyles.clonesDisplaySelectedStyle;
			}
			GUI.Box ( new Rect(i*widthOffset, 0, widthOffset, Screen.height/8), new GUIContent(temp.Value.GetComponent<NEWCloneAnimation>().GUIIcon), displayStyle);
			
				//(temp.Value.GetComponent<OTAnimatingSprite>()._spriteContainer as OTSpriteAtlasCocos2D).GetFrame(3).;
			temp = temp.Next;
		}
	}
	

	void IGUI.XPressed ()
	{
		//throw new System.NotImplementedException ();
	}
	
	public void OPressed () {}
}