import React, { useEffect, useState } from "react";

function useGet(url, dependencies = []) {
  const [fetchedData, setFetchedData] = useState(null);

  useEffect(() => {
    const getData = async () => {
      let res = await fetch(url);
      let data = await res.json();
      setFetchedData(data);
    };
    getData();
  }, [...dependencies, url]);

  return fetchedData;
}

export default useGet;
