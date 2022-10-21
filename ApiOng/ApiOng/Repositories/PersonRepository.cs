using ApiOng.Controllers;
using ApiOng.Models;
using ApiOng.Utils;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ApiOng.Repositories
{
    public class PersonRepository
    {
        private readonly IMongoCollection<Person> _personRepository;
        public PersonRepository(IDatabaseSettings settings)
        {
            var person = new MongoClient(settings.ConnectionString);
            var database = person.GetDatabase(settings.DatabaseName);
            _personRepository = database.GetCollection<Person>(settings.PeoplesCollectionName);
        }

        public Person Insert(Person person)
        {
            _personRepository.InsertOne(person);
            return person;
        }
        public List<Person> Get() => _personRepository.Find(person => true).ToList();

        public Person ToLocate(string id) => _personRepository.Find(person => person.Id == id).FirstOrDefault();

        public void Update(string id, Person personIn) => _personRepository.ReplaceOne(person => person.Id == id, personIn);

        public void Remove(Person personIn) => _personRepository.DeleteOne(person => person.Id == personIn.Id);

    }
}
