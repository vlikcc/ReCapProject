using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        IOperationClaimService _operationClaimService;

        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpPost("Add")]
         public IActionResult Add(OperationClaim claim)
        {
            var result = _operationClaimService.Add(claim);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("Delete")]

        public IActionResult Delete(OperationClaim claim)
        {
            var result = _operationClaimService.Delete(claim);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetClaims")]
        public IActionResult GetAll()
        {
            var result = _operationClaimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
