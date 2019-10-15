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
        private readonly IWorkLoadRepository _workLoadRepository;
        public ObligationController(IObligationRepository repository, IDebtRepository debtRepository, IWorkLoadRepository workLoadRepository) : base(repository)
        {
            _repository = repository;
            _debtRepository = debtRepository;
            _workLoadRepository = workLoadRepository;
        }

        [HttpPost("Adeudo/{workLoadRegistryId}")]
        public async Task<ActionResult<IEnumerable<WorkLoad>>> SetDebts([FromBody] Debt model, [FromRoute]long workLoadRegistryId)
        {
            try
            {
                await _workLoadRepository.UpdateRegistry(workLoadRegistryId);
                return Ok(await _debtRepository.Create(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
