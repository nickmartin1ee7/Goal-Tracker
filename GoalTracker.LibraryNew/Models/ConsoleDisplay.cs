using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.LibraryNew
{
    public class ConsoleDisplay : IDisplay
    {
        public void PrintLine(string message)
        {
            Print(message + Environment.NewLine);
        }

        public void Print(string message)
        {
            Console.Write(message);
        }

        public void WaitForKey()
        {
            Print("Press any key to continue...");
            Console.ReadKey();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void PrintError(string errorMessage)
        {
            PrintLine($"Error: {errorMessage}");
        }
    }
}
