import { useEffect, useState } from "react";
import { TOpStation, TZone } from "../../types/LineTypes";
import { AsyncFetchEndpointAndSetStateWithRetry } from "../../services/APIService";
import OpStationMan from "./components/OpStationMan";
import ZoneDropdown from "./components/ZoneDropdown";
import { NonNegativeInteger } from "../../types/GenericTypes";
import { useSelector } from "react-redux";
import { RootState } from "../../types/ReduxTypes";

const getSelectedZone = (zones: TZone[], opstation: TOpStation): string => zones.find(x => x.id === opstation.zoneID)!.zoneName;

export default function StationManagement() {
    const [zones, setZones] = useState<TZone[]>();
    const [selectedOpStation, setSelectedOpStation] = useState<TOpStation>();
    const token = useSelector((state: RootState) => state.auth.token)

    useEffect(() => {
        if (!zones) AsyncFetchEndpointAndSetStateWithRetry<TZone[], NonNegativeInteger<3>>(setZones, "Line", 3, token!)
    })

    return(
        <section>
            <div className="stations-list d-flex gap-2 flex-row mb-5">
                {zones && zones.map((zone) => <ZoneDropdown key={zone.id} {...{zone, setSelectedOpStation }} />)}
            </div>
            {selectedOpStation && token &&
                <div className="station-editor">
                    {zones && selectedOpStation && <h2>{getSelectedZone(zones, selectedOpStation)}</h2>}
                    {<OpStationMan selectedStation={selectedOpStation} token={token} />}
                </div>
            }
        </section>
    )
}
