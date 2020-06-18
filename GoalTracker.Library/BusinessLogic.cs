using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using static System.Console;

namespace GoalTracker.Library
{
    public static class BusinessLogic
    {
        #region Properties
        private const string ProfilesFile = "profiles.json";
        public static List<Profile> Profiles { get; private set; }
        #endregion

        #region Public
        public static Profile MakeProfile()
        {
            while (true)
            {
                try
                {
                    Clear();

                    WriteLine("== New profile Setup ==" + Environment.NewLine);

                    Write("Goal: ");
                    string goal = ReadLine();

                    Write("Start Date: ");
                    DateTime sDate = DateTime.Parse(ReadLine());

                    Write("End Date: ");
                    DateTime eDate = DateTime.Parse(ReadLine());

                    if (eDate > sDate)
                    {
                        Profile newProfile = new Profile(goal, sDate, eDate);

                        Profiles.Add(newProfile);
                        SaveProfiles(Profiles);

                        return newProfile;
                    }
                    else throw new FormatException();
                }
                catch (FormatException)
                {
                    WriteLine($"Error: Your input was not in a valid format (01-01-20, 1/1/2020)." + Environment.NewLine + "Press any key to start over...");
                    ReadKey();
                }
            }
        }

        public static bool DeleteProfiles()
        {
            try
            {
                File.Delete(ProfilesFile);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempt to deserialize profile json file
        /// </summary>
        /// <returns>Returns deserialized List<Profile>. On exception, return empty list</returns>
        public static Profile[] LoadProfiles()
        {
            try
            {
                var jsonProfiles = File.ReadAllText(ProfilesFile);
                Profiles = JsonSerializer.Deserialize<List<Profile>>(jsonProfiles);
                if (Profiles.Count == 0)
                    throw new Exception("Empty Profiles JSON file");
                return Profiles.ToArray();
            }
            catch (Exception)
            {
                Profiles = new List<Profile>();
                return new List<Profile>().ToArray();
            }
        }

        /// <summary>
        /// Attempt to save a List<Profiles> to ProfilesFile in working dir of Program
        /// </summary>
        /// <param name="profiles"></param>
        /// <returns>Boolean if serializing was successful</returns>
        public static bool SaveProfiles(List<Profile> profiles)
        {
            try
            {
                var jsonProfiles = JsonSerializer.Serialize(profiles);
                File.WriteAllText(ProfilesFile, jsonProfiles);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempt to save all Profiles currently in memory
        /// </summary>
        /// <returns>Boolean if serializing was successful</returns>
        public static bool SaveProfiles()
        {
            try
            {
                var jsonProfiles = JsonSerializer.Serialize(Profiles);
                File.WriteAllText(ProfilesFile, jsonProfiles);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}