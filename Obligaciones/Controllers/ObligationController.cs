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
    public class ObligationController : GenericController<Obligation>
    {
        private readonly IObligationRepository _repository;
        private readonly IDebtRepository _debtRepository;
        public ObligationController(IObligationRepository repository, IDebtRepository debtRepository) : base(repository)
        {
            _repository = repository;
            _debtRepository = debtRepository;
        }

        [HttpPost("Adeudo")]
        public async Task<ActionResult<IEnumerable<WorkLoad>>> SetDebts([FromBody] Debt model)
        {
            try
            {
                return Ok(await _debtRepository.Create(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
