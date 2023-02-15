type TZone = {
  id: number;
  zoneName: string;
  opStations: TOpStation[];
}

type TOpStation = {
  id: number;
  stationName: string;
  zoneID: number;
  trainingRequirements: TTrainingRequirement[];
}

type TTrainingRequirement = {
  id: number;
  requirementDescription: string;
  trainingRequirementType: TTrainingRequirementType;
  trainingRequirementTypeId: number;
  opStationID: number;
}

type TTrainingRequirementType = {
  id: number;
  trainingType: TrainingTypes;
}

enum TrainingTypes {
  Prerequisite = "Prerequisite",
  StandardOperatingProcedure = "StandardOperatingProcedure",
  TrainerCapable = "TrainerCapable"
}

export type { TZone, TOpStation, TTrainingRequirement, TTrainingRequirementType }
export {TrainingTypes}