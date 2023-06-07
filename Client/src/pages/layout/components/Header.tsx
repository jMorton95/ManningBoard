import { useSelector } from 'react-redux'
import { type RootState } from '../../../types/ReduxTypes'
import ClockIn from '../../../services/authentication/components/ClockIn'
import { useState } from 'react'
import NavBar from './Navbar'

export default function Header(): JSX.Element {
  const [enableLogin, setEnableLogin] = useState(false)

  const token = useSelector((state: RootState) => state.auth.token)
  console.log(token)
  const toggleLogin = (): void => { setEnableLogin(!enableLogin) }

  console.log(enableLogin)

  return (
    <section className="d-flex header-component">
      {token === null && (
        <button className="btn btn-primary fw-light fs-6" onClick={toggleLogin}>
          {!enableLogin ? 'LogIn' : 'Close'}
        </button>
      )}
      {enableLogin && (
        token !== null
          ? <NavBar setEnableLogin={setEnableLogin} />
          : <ClockIn />
      )
      }
    </section>
  )
}
