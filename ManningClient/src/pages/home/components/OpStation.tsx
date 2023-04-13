import { useEffect, useState } from "react";
import { AsyncFetchEndpointAndSetState } from "../../../services/APIService";
import { TOpStation } from "../../../types/LineTypes";
import { EStatusColor, TOperatorGrouped } from "../../../types/OperatorTypes";

export default function OpStation(props: TOpStation) {
	const [opstationOperators, setOpstationOperators] = useState<TOperatorGrouped[]>();

	// useEffect(() => {
	// 	if (!opstationOperators) {
	// 		AsyncFetchEndpointAndSetState<TOperatorGrouped[]>(setOpstationOperators, `Soa/${props.id}`);
    //     }
    //     if(props.id === 12) console.log(opstationOperators)
	// }, [opstationOperators]);

    return (
        <div className={"opstation col pt-2"}>
            {/* <p>{props.stationName}</p>
            {opstationOperators && opstationOperators.map(op => {
                if (op.color === EStatusColor.Green) {
                 return <p style={{color: "green"}}>{op.operator.operatorName}</p>   
               } 
            })} */}
        </div>
    )
}
