import { type TTrainingRequirement } from '../types/models/LineTypes';

type TFilteredRequirementProps = {
  filter: TTrainingRequirement[]
  title: string
}

export default function FilteredRequirementList(props: TFilteredRequirementProps): JSX.Element {
  return (
    <div className="col">
      {props.title}
      <ul className="list-group width-max-content">
        {props.filter.map((pre) => (
          <li className={'requirement list-group-item'} key={pre.id}>{pre.requirementDescription}</li>
        ))}
      </ul>
    </div>
  );
}
