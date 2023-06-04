import { useState } from "react";
import { FetchPost, PostRequestBase } from "../../../services/APIService";
import { TTrainingRequirement } from "../../../types/LineTypes";
import { TRequirementPostData } from "../../../types/TrainingTypes";

type TAddRequirementProps = {
  closeModal: React.Dispatch<React.SetStateAction<boolean>>,
  opstationID: number,
  trainingRequirements: TTrainingRequirement[],
  setRequirements: React.Dispatch<React.SetStateAction<TTrainingRequirement[]>>,
  token: string,
};

export default function AddRequirement(props: TAddRequirementProps) {
  const [requirementDescription, setRequirementDescription] = useState<string>('');

  const PostRequirement = async (e: React.FormEvent, token: string) => {
    e.preventDefault();
    await FetchPost<TTrainingRequirement, TRequirementPostData>({
      endpoint: "TrainingRequirement",
      data: {
        requirementDescription: requirementDescription,
        opstationID: props.opstationID,
      },
      request: PostRequestBase(token),
    }).then((res) => {
      props.setRequirements([...props.trainingRequirements, res]);
      setRequirementDescription('');
    }).catch((err) => {
      console.error(err);
     });
  };

  return (
    <div className={"addRequirementModal"}>
      <button type="button" onClick={(e) => props.closeModal(false)}>Close</button>
      <form onSubmit={(e: React.FormEvent) => PostRequirement(e, props.token) }>
        <label title="requirementDescription" htmlFor="requirementDescription">
          Requirement:
          <input type="text"
                  name="requirementDescription"
                  id="requirementDescription"
                  value={requirementDescription}
                  onChange={(e) => setRequirementDescription(e.target.value)}
          />
        </label>
        <button type="submit">
            Submit Requirement
        </button>
      </form>
    </div>
  )
}