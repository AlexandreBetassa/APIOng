using ApiOng.Models;
using ApiOng.Utils;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ApiOng.Repositories
{
    public class AnimalRepository
    {
        private readonly IMongoCollection<Animal> _animalRepository;
        public AnimalRepository(IDatabaseSettings settings)
        {
            var animal = new MongoClient(settings.ConnectionString);
            var database = animal.GetDatabase(settings.DatabaseName);
            _animalRepository = database.GetCollection<Animal>(settings.AnimalsCollectionName);
        }

        public Animal Post(Animal animal)
        {
            _animalRepository.InsertOne(animal);
            return animal;
        }

        public List<Animal> Get() => _animalRepository.Find(x => true).ToList();

        public Animal ToLocate(string id) => _animalRepository.Find(animal => animal.Id == id).FirstOrDefault();

        public void Put(string id, Animal animalIn) => _animalRepository.ReplaceOne(animal => animal.Id == id, animalIn);

        public void Remove(Animal animalIn) => _animalRepository.DeleteOne(animal => animal.Id == animalIn.Id);
    }
}
