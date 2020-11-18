using System;
using System.IO;
using GoalTracker.Library.Models.Interfaces;
using GoalTracker.Library.Models.Repositories;
using Newtonsoft.Json;

namespace GoalTracker.Library.Models.DataContexts
{
    class JsonDataContext : IDataContext
    {
        public FileInfo DatabaseFile { get; set; } = new FileInfo("Goals.json");

        public IGoalRepository LoadDatabase()
        {
            if (!DatabaseFile.Exists)
            {
                File.Create(DatabaseFile.FullName);
                DatabaseFile = new FileInfo(DatabaseFile.FullName);
            }

            try
            {
                IGoalRepository db = JsonConvert.DeserializeObject<GoalRepository>(File.ReadAllText(DatabaseFile.FullName));
                if (db?.GoalList?.Count > 0)
                    return db;
                else throw new Exception("Database file contains no database object or goals!");
            }
            catch (Exception)
            {
                return Factory.GetDatabase();
            }
        }

        public bool SaveDatabase(IGoalRepository database)
        {
            try
            {
                File.WriteAllText(DatabaseFile.FullName, JsonConvert.SerializeObject(database));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
