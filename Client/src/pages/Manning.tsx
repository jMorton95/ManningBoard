import Line from "@/components/manning/Line";
import { LineProvider } from "@/contexts/LineProvider";

export default function Manning(): JSX.Element {
  return (
    <section className={"text-slate-950"}>
      <LineProvider>
        <Line />
      </LineProvider>
    </section>
  );
}
