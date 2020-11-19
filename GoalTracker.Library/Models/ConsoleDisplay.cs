using System;
using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models
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

        public void Clear()
        {
            Console.Clear();
        }

        public void PrintError(string errorMessage)
        {
            PrintLine($"Error: {errorMessage}");
        }
    }
}
