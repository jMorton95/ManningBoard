import { type ZoneStateDTO } from "@/types/dtos/LineState";
import Station from "./Station";

type ZoneProps = {
  zoneStateDTO: ZoneStateDTO;
};

export default function Zone({ zoneStateDTO }: ZoneProps): JSX.Element {
  const { zone, stationStateDTOs } = zoneStateDTO;

  return (
    <div className={""}>
      <h2>{zone.zoneName}</h2>
      <div className="zone row">
        {stationStateDTOs.map((dto) => (
          <Station key={dto.station.id} {...dto} />
        ))}
      </div>
    </div>
  );
}
