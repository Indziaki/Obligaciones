using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligaciones.Repositories;

// For more information on enabling Web API for empty projects, Uisit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligaciones.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class GenericController<U> : Controller where U : class
    {
        public readonly IGenericRepository<U> _repository;

        public GenericController(IGenericRepository<U> repository)
        {
            _repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<U>>> GetAll()
        {
            try
            {
                return Ok(await _repository.GetAll());
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/[controller]/5
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<U>> Get(long id)
        {
            try
            {
                return Ok(await _repository.GetById(id));
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/[controller]
        [HttpPost]
        public virtual async Task<ActionResult<U>> Post([FromBody]U model)
        {
            try
            {
                return Ok(await _repository.Create(model));
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/[controller]/5
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<U>> Put(int id, [FromBody]U model)
        {
            try
            {
                return Ok(await _repository.Update(id, model));
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/[controller]/5
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Ok(new { deleted = await _repository.Delete(id) });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
        }
        protected long getUser()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var id = identity.FindFirst(JwtRegisteredClaimNames.UniqueName)?.Value;
                    return long.Parse(id);
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
