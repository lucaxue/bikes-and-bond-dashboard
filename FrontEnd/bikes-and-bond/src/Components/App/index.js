import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import DashboardProfilePage from "../DashboardProfilePage";
import BikesPage from "../BikesPage";
import MissionsPage from "../MissionsPage";
import { useAuth0 } from "@auth0/auth0-react";
import { ThemeContextProvider, useThemeContext } from "../../libs/themeContext";
import styles from "./App.module.css";

function App() {
  const { loginWithRedirect } = useAuth0();
  const { theme } = useThemeContext();
  return (
    <ThemeContextProvider>
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
            <div style={theme} className={styles.flex}>
              <button
                onClick={loginWithRedirect}
                style={{
                  fontSize: "60px",
                  textAlign: "center",
                  padding: "30px",
                  borderRadius: "10px",
                  border: "none",
                }}
              >
                Login to dashboard
              </button>
            </div>
          </Route>
        </Switch>
      </Router>
    </ThemeContextProvider>
  );
}

export default App;
