using System;
using static System.Console;
using GoalTracker.Library;
using System.Text.Json;

namespace GoalTracker.Console
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Clear();
                WriteLine("== Goal Tracker ==" + Environment.NewLine);

                Profile[] profiles = BusinessLogic.LoadProfiles();

                if (profiles.Length == 0)
                {
                        Write("Setup new profile (Y/N)? ");
                        string r = ReadLine().ToUpper();

                        if (r == "Y")
                            BusinessLogic.MakeProfile();
                }
                else
                {
                    for (int i = 0; i < profiles.Length; ++i)
                    {
                        WriteLine($"[{i}/{profiles.Length}]\t{profiles[i]}");
                    }
                    Write(Environment.NewLine + "Enter profile # or enter (N)ew: ");
                    var response = ReadLine();
                    if (int.TryParse(response, out int profileNum))
                    {
                        Clear();
                        WriteLine(profiles[profileNum]);
                        ReadKey();
                    }
                    else if (response.ToUpper() == "N" || response.ToUpper() == "New")
                    {
                        BusinessLogic.MakeProfile();
                    }
                    else
                    {
                        WriteLine($"Error: {response} is an invalid option!");
                        ReadKey();
                    }
                }
            }
        }
    }
}
