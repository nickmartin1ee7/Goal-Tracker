﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace GoalTracker.LibraryNew
{
    class JsonDataContext : IDataContext
    {
        public FileInfo DatabaseFile { get; set; } = new FileInfo("Goals.json");

        public IDatabase LoadDatabase()
        {
            if (!DatabaseFile.Exists)
            {
                using (File.Create(DatabaseFile.FullName));
                DatabaseFile = new FileInfo(DatabaseFile.FullName);
            }

            try
            {
                IDatabase db = JsonConvert.DeserializeObject<Database>(File.ReadAllText(DatabaseFile.FullName));
                if (db?.GoalList?.Count > 0)
                    return db;
                else throw new Exception("Databse file contains no database object or goals!");
            }
            catch (Exception e)
            {
                return Factory.GetDatabase();
            }
        }

        public bool SaveDatabase(IDatabase database)
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
