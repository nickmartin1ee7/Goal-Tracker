using System;
using System.IO;
using GoalTracker.Library.Models.Interfaces;
using GoalTracker.Library.Models.Repositories;
using Newtonsoft.Json;

namespace GoalTracker.Library.Models.DataContexts
{
    class JsonDataContext : IDataContext
    {
        public FileInfo RepositoryFile { get; set; } = new FileInfo("Goals.json");

        public IGoalRepository ReadRepository()
        {
            if (!RepositoryFile.Exists)
            {
                File.Create(RepositoryFile.FullName);
                RepositoryFile = new FileInfo(RepositoryFile.FullName);
            }

            try
            {
                IGoalRepository repo = JsonConvert.DeserializeObject<GoalRepository>(File.ReadAllText(RepositoryFile.FullName));
                if (repo?.GoalList.Count > 0)
                    return repo;
                else throw new Exception("Repository file contains no repository object or goals!");
            }
            catch (Exception)
            {
                return Factory.GetRepository();
            }
        }

        public bool WriteRepository(IGoalRepository repository)
        {
            try
            {
                File.WriteAllText(RepositoryFile.FullName, JsonConvert.SerializeObject(repository));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
