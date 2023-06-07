import { TrainingTypes, type TTrainingRequirement } from '../types/LineTypes'
import { type TFilteredRequirements } from '../types/TrainingTypes'

/**
 * @param trainingRequirements Expects an Array of Type TTrainingRequirement
 * @param filterType Expects an enum of TrainingType to filter
 * @returns An Array of type TTrainingRequirement matching only the filtered TrainingType.
 */
function GetRequirementsOfType(
  trainingRequirements: TTrainingRequirement[],
  filterType: TrainingTypes
): TTrainingRequirement[] {
  return trainingRequirements.filter(
    (x) => x.trainingRequirementType.trainingType === filterType
  )
}

/**
 * @param trainingRequirements A Blob of all TrainingRequirements from an OpStation
 * @returns An Object containing filtered Prerequisites & StandardOperatingProcedures
 */
function SplitPrerequisitesAndSOPS(
  trainingRequirements: TTrainingRequirement[]
): TFilteredRequirements {
  return {
    prerequisites: GetRequirementsOfType(
      trainingRequirements,
      TrainingTypes.Prerequisite
    ),
    standardOperatingProcedures: GetRequirementsOfType(
      trainingRequirements,
      TrainingTypes.StandardOperatingProcedure
    )
  }
}

export { SplitPrerequisitesAndSOPS }
