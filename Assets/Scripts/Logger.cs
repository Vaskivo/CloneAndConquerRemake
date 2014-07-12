using System;
using System.IO;

public class Logger
{

    private static Logger instance;
    public static Logger Instance { get { return instance; } }

    private String filePath;

    static Logger()
    {
        instance = new Logger();
    }

    private Logger()
    {
      //  filePath = "./PlayTestSession_"+ DateTime.Now.ToString()+".txt";
      //  this.writeToLog("--- STARTED NEW PLAYTEST SESSION ---");
    }
	
	public void initializeLogger(string id)
	{
#if UNITY_EDITOR
		return;
#endif
		Directory.CreateDirectory("./PlayTestLogs/"+DateTime.Now.Day);
		filePath = "./PlayTestLogs/"+ DateTime.Now.Day +"/PlayTestSession_"+ id +".txt";
        this.writeToLog("--- STARTED NEW PLAYTEST SESSION ---" + DateTime.Now.Day);//DateTime.Now.ToString());
	}
	
    public void writeToLog(string textToLog)
    {
#if UNITY_EDITOR
		return;
#endif
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(textToLog);
        }
    }

}
