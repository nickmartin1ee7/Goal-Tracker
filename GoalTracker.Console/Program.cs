using System;
using static System.Console;
using GoalTracker.Library;
using GoalTracker.LibraryNew;

namespace GoalTracker.Console
{
    class Program
    {
        #region OldDeadCode1
        public const bool UseOld = true;   // Change to [true], to use old, unmaintainable code
        public static string nl = Environment.NewLine;
        #endregion
        static void Main()
        {
            #region OldDeadCode2
            if (UseOld)
                MainMenu();
            else
            {
                #endregion
                IApplication app = Factory.GetApplication();
                app.Run();
                #region OldDeadCode3
            }
            #endregion
        }
        #region OldDeadCode4
        #region Menus
        private static void MainMenu()
        {
            while (true)
            {
                Clear();
                WriteLine("== Goal Tracker ==" + nl);

                Profile[] profiles = GoalTracker.Library.BusinessLogic.LoadProfiles();

                if (profiles.Length == 0)
                {
                        Write("Setup new profile (Y/N)? ");
                        string r = ReadLine().ToUpper();

                        if (r == "Y")
                        GoalTracker.Library.BusinessLogic.MakeProfile();
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
                        GoalTracker.Library.BusinessLogic.MakeProfile();
                    }
                    else if (response.ToUpper() == "D" || response.ToUpper() == "DELETE")
                    {
                        if (!GoalTracker.Library.BusinessLogic.DeleteProfiles())
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
                            GoalTracker.Library.BusinessLogic.SaveProfiles();
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
                            GoalTracker.Library.BusinessLogic.SaveProfiles();
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
        #endregion
    }
}
