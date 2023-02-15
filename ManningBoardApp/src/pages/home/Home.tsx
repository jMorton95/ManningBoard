import { useEffect, useState } from "react"
import { AsyncFetchEndpointAndSetState } from "../../services/APIService"
import Zone from "./components/Zone";
import { TZone } from "../../types/LineTypes";


export default function Home() {
	const [lineZones, setLineZones] = useState<TZone[]>();

	useEffect(() => {
		if (!lineZones) {
			AsyncFetchEndpointAndSetState<TZone[]>(setLineZones, "Line");
		}
	}, [lineZones]);
	
	return (
		<section className={"row"}>
			{lineZones && lineZones.map((zone) => <Zone {...zone} key={zone.id} />)}
		</section>
	);
}