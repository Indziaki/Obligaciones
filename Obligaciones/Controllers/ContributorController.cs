using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Obligaciones.Models;
using Obligaciones.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligaciones.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ContributorController : GenericController<Contributor>
    {
        private readonly IContributorRepository _repository;
        private readonly IDebtRepository _debtRepository;
        public ContributorController(IContributorRepository repository, IDebtRepository debtRepository) : base(repository)
        {
            _repository = repository;
            _debtRepository = debtRepository;
        }

        [HttpGet("Adeudos/{id}")]
        public async Task<ActionResult<IEnumerable<WorkLoad>>> GetWorkLoad([FromRoute] long id)
        {
            try
            {
                return Ok(await _debtRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
