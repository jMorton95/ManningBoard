import gear from "@/icons/gear.png";

export const LoadingSpinner = () => {
  return (
    <div className="">
      <img className="animate-spin duration-3000" src={gear} />
    </div>
  );
};
