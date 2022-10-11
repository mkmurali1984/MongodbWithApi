using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongodbWithApi.Model;

namespace MongodbWithApi.Services
{
    public class StudentServices
    {
        private readonly IMongoCollection<Students> studentsinfo;
        public StudentServices(IOptions<StudentDb> dbsettings)
        {
            var studentconnectionstring = new MongoClient(dbsettings.Value.StudentConnectionString);
            var studentdatabase = studentconnectionstring.GetDatabase(dbsettings.Value.StudentDatabase);
            studentsinfo = studentdatabase.GetCollection<Students>(dbsettings.Value.StudentDatabaseCollection);
        }


        public List<Students> GetAllStudents()
        {
            return studentsinfo.Find(_ => true).ToList();
        }


        public void AddStudentDetails(Students students)
        {
            studentsinfo.InsertOne(students);
        }

        public void DeleteStudent(string id)
        {
            studentsinfo.DeleteOne(x => x.Id == id);
        }

        public Students GetStudentById(string id)
        {
            return studentsinfo.Find(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateStudent(string id, Students students)
        {
            studentsinfo.ReplaceOne(x => x.Id == id, students);
        }
    }
}
