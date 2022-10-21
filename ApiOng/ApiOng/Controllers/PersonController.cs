using ApiOng.Models;
using ApiOng.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace ApiOng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonRepository _personRepository;
        private readonly AnimalRepository _animalRepository;
        public PersonController(PersonRepository personRepository, AnimalRepository animalRepository)
        {
            _personRepository = personRepository;
            _animalRepository = animalRepository;
        }

        [HttpPost]
        public ActionResult<Person> InsertPerson(Person person)
        {
            _animalRepository.Post(person.Animals.Last());
            _personRepository.Insert(person);
            return Ok(person);
        }

        [HttpGet("GetAllPeoples", Name = "GetAllPeoples")]
        public ActionResult<List<Person>> Get() => _personRepository.Get();

        [HttpGet("FindPerson/{id:length(24)}")]
        public ActionResult<Person> ToLocatePerson(string id)
        {
            Person person = _personRepository.ToLocate(id);
            if (person == null) return NotFound("Não encontrado");
            return Ok(person);
        }

        [HttpPut("UpdatePerson")]
        public ActionResult<Person> UpdatePerson(string id, Person personIn)
        {
            Person person = _personRepository.ToLocate(id);
            if (person == null) return NotFound("Não localizado");
            _personRepository.Update(person.Id, personIn);
            return NoContent();
        }

        [HttpPut("UpdateAnimalPerson/{id:length(24)}")] //passar em ingles
        public ActionResult<Person> Adocao(Animal animal, string id)
        {
            var person = _personRepository.ToLocate(id);
            if (person == null) return NotFound();
            person.Animals.Add(animal);
            _animalRepository.Post(person.Animals.Last());
            _personRepository.Update(id, person);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Person> RemovePerson(string id)
        {
            Person person = _personRepository.ToLocate(id);
            if (person == null) return NotFound("Não localizado");
            _personRepository.Remove(person);
            return NoContent();
        }
    }
}
