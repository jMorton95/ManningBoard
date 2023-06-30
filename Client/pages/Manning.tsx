import { LineProvider } from "../src/contexts/LineProvider";
import Line from "../src/components/manning/Line";

export default function Manning(): JSX.Element {
  return (
    <section className={"text-slate-950"}>
      <LineProvider>
        <Line />
      </LineProvider>
    </section>
  );
}
