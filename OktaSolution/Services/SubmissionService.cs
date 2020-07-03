using MongoDB.Driver;
using OktaSolution.config;
using OktaSolution.Models;
using System.Collections.Generic;
using System.Linq;

namespace OktaSolution.Services
{
    public class SubmissionService
    {
        private readonly IMongoCollection<SubMission> _submissions;

        public SubmissionService(IAppSettings settings)
        {
            MongoClient client = new MongoClient(settings.MongoConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);
            _submissions = database.GetCollection<SubMission>("Submissions");
        }

        public SubMission Create(SubMission subMission)
        {
            _submissions.InsertOne(subMission);
            return subMission;
        }

        public IList<SubMission> Read() => _submissions.Find(sub => true).ToList();

        public SubMission Find(string id) => _submissions.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(SubMission subMission)
        {
            _submissions.ReplaceOne(sub => sub.Id == subMission.Id, subMission);
        }

        public void Delete(string id) => _submissions.DeleteOne(sub => sub.Id == id);
    }
}
