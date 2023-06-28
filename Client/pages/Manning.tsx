import { LineProvider } from "../src/contexts/LineProvider";
import Line from "../src/components/manning/Line";

export default function Manning(): JSX.Element {
  return (
    <section className={"manning flex-col bg-slate-900 text-slate-950"}>
      Hello
      <LineProvider>
        <Line />
      </LineProvider>
    </section>
  );
}
