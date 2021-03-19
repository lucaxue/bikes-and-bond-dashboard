import React, { useState } from "react";
import useGet from "../../libs/useGet";
import NavBar from "../NavBar";
import Mission from "../DisplayMission";

function MissionsPage() {
  // Get all the misssions - useGet (URL/missions?search${SS}, [SS])
  // Make a search state - SS
  // Map data missions into mission components to display
  // Nav Bar
  const [search, setSearch] = useState("");
  let url = `https://localhost:5001/missions?search=${search}`;
  let missions = useGet(url, [search]);
  console.log(missions);
  if (!missions) {
    return <p>loading</p>;
  }
  return (
    <div>
      <h1>Missions</h1>
      <NavBar />
      <input
        className="Mission Box"
        value={search}
        onChange={(e) => setSearch(e.target.value)}
      />
      <div>
        {missions.map((mission) => {
          return <Mission mission={mission} />;
        })}
      </div>
    </div>
  );
}

export default MissionsPage;
