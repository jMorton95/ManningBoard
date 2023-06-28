import { useLineContext } from "../../hooks/useLineContext";
import Zone from "./Zone";

export default function Line() {
  const { lineState } = useLineContext();

  if (!lineState) {
    return <div>Loading...</div>;
  }

  return lineState.map((zone) => (
    <Zone zoneStateDTO={zone} key={zone.zone.id} />
  ));
}
