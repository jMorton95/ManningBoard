using ManningApi.Models;

namespace ManningApi.Services.Interfaces
{
    public interface ITrainingRequirementService
    {
        Task<TrainingRequirement> AddNewPrerequisite(string requirementDescription, int opstationID);
    }
}
