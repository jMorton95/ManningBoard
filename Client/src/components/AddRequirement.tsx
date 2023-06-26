import { useState } from "react";
import { type TTrainingRequirement } from "../types/models/LineTypes";
import { type TRequirementPostData } from "../types/TrainingTypes";
import { PostQuery, PostRequestBase } from "../services/ApiService";

type TAddRequirementProps = {
  closeModal: React.Dispatch<React.SetStateAction<boolean>>;
  stationID: number;
  trainingRequirements: TTrainingRequirement[];
  setRequirements: React.Dispatch<React.SetStateAction<TTrainingRequirement[]>>;
};

//TODO: Bug here where updates to requirements aren't preserved across state updates. Need to pass down latest state always.
export default function AddRequirement(
  props: TAddRequirementProps
): JSX.Element {
  const [requirementDescription, setRequirementDescription] =
    useState<string>("");

  const resolvePostData = async (): Promise<void> => {
    const requirement = await PostRequirement(
      requirementDescription,
      props.stationID
    );

    if (requirement !== null) {
      props.setRequirements((requirements) => [...requirements, requirement]);
    }

    setRequirementDescription("");
  };

  const handleSubmit = (e: React.FormEvent): void => {
    e.preventDefault();
    void resolvePostData();
  };

  return (
    <div className={"addRequirementModal"}>
      <button
        type="button"
        onClick={(_) => {
          props.closeModal(false);
        }}
      >
        Close
      </button>
      <form
        onSubmit={(e: React.FormEvent) => {
          handleSubmit(e);
        }}
      >
        <label title="requirementDescription" htmlFor="requirementDescription">
          Requirement:
          <input
            type="text"
            name="requirementDescription"
            id="requirementDescription"
            value={requirementDescription}
            onChange={(e) => {
              setRequirementDescription(e.target.value);
            }}
          />
        </label>
        <button type="submit">Submit Requirement</button>
      </form>
    </div>
  );
}

const PostRequirement = async (
  requirementDescription: string,
  stationID: number
): Promise<TTrainingRequirement | null> => {
  const fetchedData = await PostQuery<
    TTrainingRequirement,
    TRequirementPostData
  >({
    endpoint: "TrainingRequirement",
    data: {
      requirementDescription,
      stationID,
    },
    request: PostRequestBase(),
  })
    .then((res) => {
      return res;
    })
    .catch((err) => {
      console.error(err);
      return null;
    });

  return fetchedData;
};
