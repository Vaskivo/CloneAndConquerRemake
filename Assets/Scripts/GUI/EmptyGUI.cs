using System;

public class EmptyGUI : IGUI
{
	static EmptyGUI ()
	{
		instance = new EmptyGUI ();
	}
	
	public static EmptyGUI Instance { get { return instance; } }

	private static EmptyGUI instance;
	
	private EmptyGUI () {}
	
	public void Draw() {}
	public void XPressed() {}
	public void OPressed() {}

}

