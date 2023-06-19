using Manning.Api.Models;
using Manning.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manning.Api.Controllers
{
  [Route("api/[controller]/")]
  [ApiController]
  public class OperatorManagementController : ControllerBase
  {
    private readonly IOperatorService _operatorService;
    public OperatorManagementController(IOperatorService operatorService)
    {
      _operatorService = operatorService;
    }
    
    [HttpGet("{operatorID}")]
    public async Task<ActionResult<Operator>> GetOperatorById(int operatorID)
    {
      return Ok(await _operatorService.GetOperatorByID(operatorID));
    }
    
    [HttpGet("GetAllOperators")]
    public async Task<ActionResult<List<Operator>>> GetAllOperators()
    {
      return Ok(await _operatorService.GetAllOperators());
    }

    [HttpGet("GetTrainingForOperator/{operatorID}")]
    public async Task<ActionResult<List<TrainingRequirement>>> GetTrainingForOperator(int operatorID)
    {
      return Ok(await _operatorService.GetDetailedTrainingRequirementsForOperator(operatorID));
    }

    [HttpGet("GetIncompleteTrainingForOperator/{operatorID}")]
    public async Task<ActionResult<List<TrainingRequirement>>> GetIncompleteTrainingForOperator(int operatorID)
    {
      return Ok(await _operatorService.GetIncompleteTrainingForOperator(operatorID));
    }
  }
}