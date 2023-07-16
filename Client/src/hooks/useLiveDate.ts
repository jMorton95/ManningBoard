import { useCallback, useEffect, useState } from "react";

export const useLiveDate = () => {

  

  const createFormattedDate = useCallback(() => {

    const months = [
      "January",
      "February",
      "March",
      "April",
      "May",
      "June",
      "July",
      "August",
      "September",
      "October",
      "November",
      "December",
    ];

    const date = new Date();
    const day = date.getDate() < 10 ? `0${date.getDate()}` : date.getDate();
    const month = months[date.getMonth()];
    const time = date.toLocaleTimeString();

    return `${day} ${month} - ${time}`;
  },[]);

  const [date, setDate] = useState(createFormattedDate());

  useEffect(() => {
    createFormattedDate();
    const timer = setInterval(() => setDate(createFormattedDate()), 1000);
    return () => clearInterval(timer);
  }, [createFormattedDate]);

  return date;
};