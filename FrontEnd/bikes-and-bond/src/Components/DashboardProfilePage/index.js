import React from "react";
import { Link } from "react-router-dom";

function DashboardProfilePage(props) {
  return (
    <>
      <div>
        <p>SPY DASHBOARD 🕵️‍♀️</p>
        <nav>
          <Link to={`/missions`}>Missions</Link>
          <Link to={`/bikes`}>Bikes</Link>
        </nav>
      </div>
    </>
  );
}

export default DashboardProfilePage;
