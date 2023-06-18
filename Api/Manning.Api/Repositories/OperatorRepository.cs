using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class OperatorRepository : BaseRepository<Operator>, IOperatorRepository
    {
         public OperatorRepository(ManningDbContext dbContext) : base(dbContext)
        {
        }

  }
}
