import { BrowserRouter as Router, Route, Switch, Link } from "react-router-dom";
import DashboardProfilePage from "../DashboardProfilePage";
import BikesPage from "../BikesPage";
import MissionsPage from "../MissionsPage";

function App() {
  return (
    <Router>
      <Switch>
        <Route path="/dashboard">
          <DashboardProfilePage />
        </Route>
        <Route path="/bikes">
          <BikesPage />
        </Route>
        <Route path="/missions">
          <MissionsPage />
        </Route>
        <Route path="/">
          <Link to="/dashboard">linerijeirj</Link>
        </Route>
      </Switch>
    </Router>
  );
}

export default App;
