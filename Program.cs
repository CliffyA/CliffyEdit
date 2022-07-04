using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

namespace CliffyEdit
{
	class Buffer
	{
		public List<StringBuilder> pLineList;
		
		public void Load(string sPath)
		{
			pLineList = new List<StringBuilder>();
			
			string sFileRaw = File.ReadAllText(sPath);
			string[] sLineArray = sFileRaw.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
			foreach (string sLine in sLineArray)
			{
				pLineList.Add(new StringBuilder(sLine));
			}
		}
	}
	
	class Gui
	{
		
	}
	
	
	class Program
	{
		private static bool keepRunning = true;

    
    		static void Main(string[] args)
		{
			int nLine = 0;
			int nColumn = 0;
			
			Console.CursorVisible = false;
			
			Console.WriteLine("Hello World!");
			
			Buffer pBuffer = new Buffer();
			pBuffer.Load("Program.cs");

			
	
	
			Console.CancelKeyPress += (sender, eventArgs) => {
				eventArgs.Cancel = true;
				keepRunning = false;
			};
        
			while (keepRunning) {
				
				
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo keyPress = Console.ReadKey(intercept: true);
					
					if (keyPress.Key == ConsoleKey.Enter)
					{
						keepRunning = false;
					}
					
					if (keyPress.Key == ConsoleKey.UpArrow)
						nLine = Math.Max(nLine-1, 0);

					if (keyPress.Key == ConsoleKey.DownArrow)
						nLine = Math.Min(nLine+1, pBuffer.pLineList.Count-1);
						
					//nIndex++;
					
					//Console.Write(keyPress.KeyChar.ToString().ToUpper());

					//keyPress = Console.ReadKey(intercept: true);
					
					Console.SetCursorPosition(0, 0);//Console.WindowHeight);
					Console.WriteLine(pBuffer.pLineList[nLine].ToString());
				}
				
				System.Threading.Thread.Sleep(10);
			}
			Console.WriteLine();
			
			
			
			
			
			/*char c = 'x';
			while (true)
			{
				if (c == 'x')
					c = 'y';
				else if (c == 'y')
					c = 'x';
				 for (int i = 10; i < 30 ; i++) // Console.WindowHeight
                {
                    for (int j = 10; j < 20; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        //Console.ForegroundColor = ColorArray[j, i];
                        Console.Write(c);

                    }
                }

                Console.ResetColor();
                
				System.Threading.Thread.Sleep(10);
			}*/
			
			Console.CursorVisible = true;
		}
	}
}
