/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactManningPoCAPI.Repositories;

namespace ReactManningPoCAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly ManningDbContext _dbContext;
        public OperatorsController(ManningDbContext context)
        {
            _dbContext = context;
        }
        
        [HttpGet]
        public async Task<IEnumerable<string>>? Get()
        {
            var operators = await _dbContext.Operator.ToListAsync();
            var arrOfNames = operators.Select(x => x.OperatorName + x.ClockCardNumber.ToString()).ToList();
            return arrOfNames;
        }

        [HttpGet("{id}")]
        public string? Get(int id)
        {
            var query = _dbContext.Operator.FirstOrDefault(x => x.ID == id);

            return (query != null) ? query.OperatorName : "Empty";
            
        }
    }
}
*/