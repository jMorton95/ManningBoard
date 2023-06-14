export default function Station(): JSX.Element {
  //const [opstationOperators, setOpstationOperators] = useState<TOperatorGrouped[]>()

  /*useEffect(() => {
    if (!opstationOperators) {
      AsyncFetchEndpointAndSetState<TOperatorGrouped[]>(setOpstationOperators, `Soa/${props.id}`);
       }
       if(props.id === 12) console.log(opstationOperators)
   }, [opstationOperators]);
   */

  return (
    <div className={'opstation col pt-2'}>
      {/*<p>{props.stationName}</p>
            {opstationOperators && opstationOperators.map(op => {
                if (op.color === EStatusColor.Green) {
                 return <p style={{color: "green"}}>{op.operator.operatorName}</p>
               }
            })} */}
    </div>
  )
}
