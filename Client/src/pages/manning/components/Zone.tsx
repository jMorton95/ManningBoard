import { type ZoneStateDTO } from "@/types/dtos/LineState";
import Station from "./Station";

type ZoneProps = {
  zoneStateDTO: ZoneStateDTO;
} & React.HTMLAttributes<HTMLDivElement>;

export default function Zone({ zoneStateDTO, ...props }: ZoneProps): JSX.Element {
  const { zone, stationStateDTOs } = zoneStateDTO;

  return (
    <div className={`${props.className} flex flex-col py-2`}>
      <h2 className="w-full text-xl font-bold px-6 align-middle">{zone.zoneName}</h2>
      <div className="flex justify-start gap-4 h-full px-6">
        {stationStateDTOs.map((dto) => (
          <Station key={dto.station.id} stationState={dto} className="py-2 h-full w-1/4 max-w-[400px]" />
        ))}
      </div>
    </div>
  );
}
