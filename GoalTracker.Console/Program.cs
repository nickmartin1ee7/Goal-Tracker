using System;
using static System.Console;
using GoalTracker.Library;

namespace GoalTracker.Console
{
    class Program
    {
        public static string nl = Environment.NewLine;

        static void Main()
        {
            MainMenu();
        }

        #region Menus
        private static void MainMenu()
        {
            while (true)
            {
                Clear();
                WriteLine("== Goal Tracker ==" + nl);

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
                        WriteLine($"[{i+1}/{profiles.Length}]\t{profiles[i]}{nl}Finished: {profiles[i].Finished}{nl}");
                    }
                    Write(nl + "Enter profile #,(N)ew, or (D)elete all profiles: ");
                    var response = ReadLine();
                    if (int.TryParse(response, out int profileNum))
                    {
                        profileNum--;
                        if (profileNum >= 0 && profileNum < profiles.Length)
                            ModifyProfileMenu(profiles[profileNum]);
                        else
                        {
                            WriteLine($"Error: {profileNum} is an invalid option!");
                            ReadKey();
                        }
                    }
                    else if (response.ToUpper() == "N" || response.ToUpper() == "NEW")
                    {
                        BusinessLogic.MakeProfile();
                    }
                    else if (response.ToUpper() == "D" || response.ToUpper() == "DELETE")
                    {
                        if (!BusinessLogic.DeleteProfiles())
                        {
                            WriteLine("Error: Failed to delete profiles file!");
                            ReadKey();
                        }
                    }
                    else
                    {
                        WriteLine($"Error: {response} is an invalid option!");
                        ReadKey();
                    }
                }
            }
        }

        private static void ModifyProfileMenu(Profile profile)
        {
            bool escape = false;
            while (!escape)
            {
                try
                {
                    Clear();
                    WriteLine(profile);
                    WriteLine("Finished: " + profile.Finished);
                    WriteLine(profile.ViewProgress());

                    Write("Enter Target Date: ");
                    var td = DateTime.Parse(ReadLine());

                    Write("Did you make progress towards your goal? (Y/N): ");
                    var tp = ReadLine();
                    tp = tp.ToUpper();

                    if (tp == "Y")
                    {
                        if (profile.MakeProgress(td, true))
                        {
                            BusinessLogic.SaveProfiles();
                            escape = true;
                        }
                        else
                        {
                            WriteLine("Error: Failed to update progress!");
                            ReadKey();
                        }
                    }
                    else if (tp == "N")
                    {
                        if (profile.MakeProgress(td, false))
                        {
                            BusinessLogic.SaveProfiles();
                            escape = true;
                        }
                        else
                        {
                            WriteLine("Error: Failed to update progress!");
                            ReadKey();
                        }
                    }
                    else
                    {
                        WriteLine($"Error: {tp} is not Y or N!");
                        ReadKey();
                    }
                }
                catch (FormatException)
                {
                    WriteLine($"Error: Invalid date!");
                    ReadKey();
                    break;
                }
            }
        }
        #endregion
    }
}
