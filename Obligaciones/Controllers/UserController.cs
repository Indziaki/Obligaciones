using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Obligaciones.Models;
using Obligaciones.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligaciones.Controllers
{
    [Route("api/[controller]")]
    public class UserController : GenericController<User>
    {
        private readonly IUserRepository _repository;
        private readonly IWorkLoadRepository _wlRepository;
        public UserController(IUserRepository repository, IWorkLoadRepository wlRepository) : base(repository)
        {
            _repository = repository;
            _wlRepository = wlRepository;
        }

        public override Task<ActionResult<User>> Post([FromBody] User model)
        {
            model.Password = sha256(model.Password);
            return base.Post(model);
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] Login model)
        {
            try
            {
                var user = await _repository.GetByUserName(model.Username);
                if (user.Password.Equals(sha256(model.Password))) return Ok(new { message = "Success" });
                else throw new Exception("Usuario y contraseña inválidos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Cargas")]
        public async Task<ActionResult<IEnumerable<WorkLoad>>> GetWorkLoads()
        {
            try
            {
                return Ok(await _wlRepository.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Carga")]
        public async Task<ActionResult> SetWorkLoads([FromBody] WorkLoad model)
        {
            try
            {
                return Ok(await _wlRepository.Create(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Carga/Registros/{id}")]
        public async Task<ActionResult> SetWorkLoadRegistries([FromRoute]long id, [FromBody] IEnumerable<WorkLoadRegistry> registries)
        {
            try
            {
                return Ok(await _wlRepository.AddRegistries(id, registries));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Carga/{id}")]
        public async Task<ActionResult<IEnumerable<WorkLoad>>> GetWorkLoad([FromRoute] long id)
        {
            try
            {
                return Ok(await _wlRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private static string sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
