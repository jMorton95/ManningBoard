import Line from "./components/Line";
import { LineProvider } from "@/contexts/LineProvider";

export default function Manning(): JSX.Element {
  return (
    <section className={"text-slate-900 container-fluid flex flex-col h-full"}>
      <LineProvider>
        <Line />
        {/**Holidays & Absences */}
        <div className="h-96 bg-custom-main-200"></div>
      </LineProvider>
    </section>
  );
}
