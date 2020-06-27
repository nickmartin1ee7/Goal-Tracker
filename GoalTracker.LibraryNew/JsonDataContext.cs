using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace GoalTracker.LibraryNew
{
    class JsonDataContext : IDataContext
    {
        public FileInfo DatabaseFile { get; set; }

        public IDatabase LoadDatabase()
        {
            try
            {
                return JsonSerializer.Deserialize<Database>(File.ReadAllText(DatabaseFile.FullName));
            }
            catch (Exception)
            {
                return Factory.GetDatabase();
            }
        }

        public bool SaveDatabase(IDatabase database)
        {
            try
            {
                File.WriteAllText(DatabaseFile.FullName, JsonSerializer.Serialize(database));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
