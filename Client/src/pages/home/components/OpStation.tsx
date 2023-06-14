export default function Station(): JSX.Element {
  //const [stationOperators, setOpstationOperators] = useState<TOperatorGrouped[]>()

  /*useEffect(() => {
    if (!stationOperators) {
      AsyncFetchEndpointAndSetState<TOperatorGrouped[]>(setOpstationOperators, `Soa/${props.id}`);
       }
       if(props.id === 12) console.log(stationOperators)
   }, [stationOperators]);
   */

  return (
    <div className={'station col pt-2'}>
      {/*<p>{props.stationName}</p>
            {stationOperators && stationOperators.map(op => {
                if (op.color === EStatusColor.Green) {
                 return <p style={{color: "green"}}>{op.operator.operatorName}</p>
               }
            })} */}
    </div>
  )
}
