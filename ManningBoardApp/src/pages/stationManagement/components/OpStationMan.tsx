import { useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { SplitPrerequisitesAndSOPS } from "../../../services/TrainingRequirementService";
import { TOpStation } from "../../../types/LineTypes";
import AddRequirement from "./AddRequirement";
import FilteredRequirementList from "./FilteredRequirementList";


export default function OpStationMan(props: TOpStation) {

  const [addRequirement, setAddRequirement] = useState<Boolean>(false);
  const [requirements, setRequirements] = useState(SplitPrerequisitesAndSOPS(props.trainingRequirements).prerequisites);

  useEffect(() => {
    setRequirements(props.trainingRequirements)
  },[props.trainingRequirements])

  return (
    <div className="opstationman container row border-light-30 p-3">
      <div className="col-2">
        <h3 className="width-100-percent">{`Station: ${props.stationName}`}</h3>
        <h4>StationID: {props.id}</h4>
        <Button onClick={() => setAddRequirement(true)} type="button">
          Add Requirement
        </Button>
      </div>
      {requirements && (
        <FilteredRequirementList
          filter={requirements}
          title={"Prerequisites"}
        />
      )}
    {addRequirement && (
      <AddRequirement
        closeModal={() => setAddRequirement(false)}
        opstationID={props.id}
          trainingRequirements={requirements}
          setRequirements={setRequirements}
        />
      )}
    </div>
  );
}