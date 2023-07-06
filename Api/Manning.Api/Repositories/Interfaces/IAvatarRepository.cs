using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IAvatarRepository : IBaseRepository<AvatarModel>
    {
      Task<AvatarModel> GetAvatarModelByOperatorID(int operatorID);
    }
}
