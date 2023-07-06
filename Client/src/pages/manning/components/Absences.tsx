type AbsencesProps = React.HTMLAttributes<HTMLDivElement>;

export default function Absences({ ...props }: AbsencesProps) {
  return (
    <div className={`${props.className}`}>
      <div>holiday</div>
      <div>absence</div>
    </div>
  );
}
