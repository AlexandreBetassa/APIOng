using ApiOng.Models;
using ApiOng.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ApiOng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly AdressRepository _adressRepository;
        public AdressController() 
        {
            _adressRepository = new AdressRepository();
        }

    [HttpGet("{cep}")]
        public ActionResult<Adress> GetAdress(string cep)
        {
            var adress = _adressRepository.GetAdress(cep).Result;
            if (adress == null) return NotFound();
            return Ok(adress);
        }
    }
}
