using Microsoft.EntityFrameworkCore;
using Manning.Api.Models;
using Manning.Api.Repositories.Interfaces;

namespace Manning.Api.Repositories
{
    public class AvatarRepository : BaseRepository<AvatarModel>, IAvatarRepository
    {
      public AvatarRepository(ManningDbContext context) : base(context)
      {
        
      }

      public async Task<AvatarModel> GetAvatarModelByOperatorID(int operatorID)
      {
        return await _dbContext.AvatarModels.FirstOrDefaultAsync(x => x.OperatorID == operatorID)!;
      }
  }
}