import { useState } from 'react'
import { FetchPost, PostRequestBase } from '../../../services/APIService'
import { type TTrainingRequirement } from '../../../types/LineTypes'
import { type TRequirementPostData } from '../../../types/TrainingTypes'

interface TAddRequirementProps {
  closeModal: React.Dispatch<React.SetStateAction<boolean>>
  opstationID: number
  trainingRequirements: TTrainingRequirement[]
  setRequirements: React.Dispatch<React.SetStateAction<TTrainingRequirement[]>>
  token: string
}

//TODO: Bug here where updates to requirements aren't preserved across state updates. Need to pass down latest state always.
export default function AddRequirement(props: TAddRequirementProps): JSX.Element {
  const [requirementDescription, setRequirementDescription] = useState<string>('')

  const resolvePostData = async(): Promise<void> => {
    const requirement = await PostRequirement(props.token, requirementDescription, props.opstationID)

    if (requirement !== null) {
      props.setRequirements((requirements) => [...requirements, requirement])
    }

    setRequirementDescription('')
  }

  const handleSubmit = (e: React.FormEvent): void => {
    e.preventDefault()
    void resolvePostData()
  }

  return (
    <div className={'addRequirementModal'}>
      <button type="button" onClick={(_) => { props.closeModal(false) }}>Close</button>
      <form onSubmit={(e: React.FormEvent) => { handleSubmit(e) } }>
        <label title="requirementDescription" htmlFor="requirementDescription">
          Requirement:
          <input type="text"
            name="requirementDescription"
            id="requirementDescription"
            value={requirementDescription}
            onChange={(e) => { setRequirementDescription(e.target.value) }}
          />
        </label>
        <button type="submit">
            Submit Requirement
        </button>
      </form>
    </div>
  )
}

const PostRequirement = async(token: string, requirementDescription: string, opstationID: number): Promise<TTrainingRequirement | null> => {
  const fetchedData = await FetchPost<TTrainingRequirement, TRequirementPostData>({
    endpoint: 'TrainingRequirement',
    data: {
      requirementDescription,
      opstationID
    },
    request: PostRequestBase(token)
  }).then((res) => {
    return res
  }).catch((err) => {
    console.error(err)
    return null
  })

  return fetchedData
}