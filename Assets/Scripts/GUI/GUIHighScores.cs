using UnityEngine;
using System.Collections;

public class GUIHighScores : IGUI {
	
	static GUIHighScores()
	{
		instance = new GUIHighScores();
	}
	
	public static GUIHighScores Instance {get {return instance;}}
	private static GUIHighScores instance;
	
	private GUIHighScores()
	{
		//initialize variables like sizes, positions, etc...		
	}
	
	public void Draw() { }
	
	public void XPressed() {}
	
	public void OPressed () {}
}
