import { type StationStateDTO } from "../../types/dtos/LineState";

export default function Station(props: StationStateDTO): JSX.Element {
  const { station, operator } = props;

  return (
    <div className={"station col pt-2"}>
      <p>{station.stationName}</p>
      {operator != null ? <p>{operator.operatorName}</p> : <p>Unassigned</p>}
    </div>
  );
}
