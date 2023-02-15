using ReactManningPoCAPI.Models;

namespace ReactManningPoCAPI.Services.Interfaces
{
    public interface ITrainingRequirementService
    {
        Task<TrainingRequirement> AddNewPrerequisite(string requirementDescription, int opstationID);
    }
}
