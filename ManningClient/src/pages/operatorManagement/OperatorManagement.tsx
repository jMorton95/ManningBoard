import { useSelector } from "react-redux";
import Login from "../layout/components/Login"
import { RootState } from "../../services/authentication/store";

export default function OperatorManagement()  {
    const token = useSelector((state: RootState) => state.auth.token);
    const user = useSelector((state: RootState) => state.user.currentUser)
    return(
        <section>
            {(token && user) ? (
                <div>
                    <h2>Operator Management</h2>
                    <p>Manage your Operators Here</p>
                    <p>Hello {user.operatorName}</p>
                </div>
              ) : (
                  <Login />
              ) 
            }
        </section>
    )
}