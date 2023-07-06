import { type ZoneStateDTO } from "@/types/dtos/LineState";
import Station from "./Station";

type ZoneProps = {
  zoneStateDTO: ZoneStateDTO;
} & React.HTMLAttributes<HTMLDivElement>;

export default function Zone({
  zoneStateDTO,
  ...props
}: ZoneProps): JSX.Element {
  const { zone, stationStateDTOs } = zoneStateDTO;

  return (
    <div className={`${props.className} flex flex-col h-full`}>
      <h2 className="w-full text-xl font-bold ps-12">{zone.zoneName}</h2>
      <div className="flex justify-around h-full px-6">
        {stationStateDTOs.map((dto) => (
          <Station
            key={dto.station.id}
            stationState={dto}
            className="border border-gray-900 col py-2 h-full"
          />
        ))}
      </div>
    </div>
  );
}
