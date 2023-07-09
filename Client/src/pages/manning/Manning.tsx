import Line from "./components/Line";
import { LineProvider } from "@/contexts/LineProvider";

export default function Manning(): JSX.Element {
  return (
    <section
      className={
        "text-slate-900 container-fluid flex flex-col justify-between h-full"
      }
    >
      <LineProvider>
        <Line />
      </LineProvider>
    </section>
  );
}
