import { useEffect, useState } from 'react';

function useGet(url, dependencies = []) {
  const [fetchedData, setFetchedData] = useState(null);

  useEffect(() => {
    const getData = async () => {
      let res = await fetch(url);
      let data = await res.json();
      setFetchedData(data);
    };
    getData();
    // eslint-disable-next-line
  }, [...dependencies, url]);

  return fetchedData;
}

export default useGet;
