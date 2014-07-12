using System;
using System.Windows.Forms;

namespace INIConfiguration
{
	public class Program
	{
   		public Program ()
		{
		}
		
		public static void Main(string[] args)
		{
            Application.Run(new INIConfiguration.Source.INICreatorForm());
		}
	}
}

