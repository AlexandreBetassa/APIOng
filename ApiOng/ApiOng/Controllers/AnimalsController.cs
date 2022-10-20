using ApiOng.Models;
using ApiOng.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiOng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalRepository _animalsRepository;
        public AnimalsController(AnimalRepository animals) => _animalsRepository = animals;

        [HttpPost]
        public ActionResult<Animal> InsertAnimal(Animal animal)
        {
            _animalsRepository.Post(animal);
            return animal;
        }

        [HttpGet("GetAll", Name = "GetAllAnimals")]
        public ActionResult<List<Animal>> GetAnimals() => _animalsRepository.Get();

        [HttpGet("FindAnimal/{id:length(24)}", Name = "FindAnimal")]
        public ActionResult<Animal> ToLocate(string id)
        {
            var animal = _animalsRepository.ToLocate(id);
            if (animal == null) return NotFound("Não localizado");
            return Ok(animal);
        }

        [HttpPut]
        public ActionResult<Animal> UpdateAnimal(Animal animalIn, string id)
        {
            Animal animal = _animalsRepository.ToLocate(id);
            if (animal == null) return NotFound("Não localizado");
            _animalsRepository.Put(animal.Id, animalIn);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Animal> DeleteAnimal(string id)
        {
            Animal animal = _animalsRepository.ToLocate(id);
            if (animal == null) return NotFound("Não localizado");
            _animalsRepository.Remove(animal);
            return NoContent();
        }
    }
}
