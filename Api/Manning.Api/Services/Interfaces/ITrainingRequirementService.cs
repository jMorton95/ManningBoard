using Manning.Api.Models;

namespace Manning.Api.Services.Interfaces
{
    public interface ITrainingRequirementService
    {
        Task<TrainingRequirement> AddNewPrerequisite(string requirementDescription, int stationID);
    }
}
