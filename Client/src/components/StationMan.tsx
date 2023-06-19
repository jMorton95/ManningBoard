import { useEffect, useState } from 'react';
import { Button } from 'react-bootstrap';
import AddRequirement from './AddRequirement';
import FilteredRequirementList from './FilteredRequirementList';
import { type TStation } from '../types/models/LineTypes';

type TStationManProps = {
  selectedStation: TStation
  token: string
}

export default function StationMan(props: TStationManProps): JSX.Element {
  const [addRequirement, setAddRequirement] = useState<boolean>(false);
  const [requirements, setRequirements] = useState(props.selectedStation.trainingRequirements);

  useEffect(() => {
    setRequirements(props.selectedStation.trainingRequirements);
  }, [props.selectedStation.trainingRequirements]);

  return (
    <div className="stationman container row border-light-30 p-3">
      <div className="col-2">
        <h3 className="width-100-percent">{`Station: ${props.selectedStation.stationName}`}</h3>
        <h4>StationID: {props.selectedStation.id}</h4>
        <Button onClick={() => { setAddRequirement(true); }} type="button">
          Add Requirement
        </Button>
      </div>
      <FilteredRequirementList
        filter={requirements}
        title={'Prerequisites'}
      />
      {addRequirement && (
        <AddRequirement
          closeModal={() => { setAddRequirement(false); }}
          stationID={props.selectedStation.id}
          trainingRequirements={requirements}
          setRequirements={setRequirements}
          token={props.token}
        />
      )}
    </div>
  );
}
