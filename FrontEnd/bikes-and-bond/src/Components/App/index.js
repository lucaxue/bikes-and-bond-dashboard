import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import DashboardProfilePage from '../DashboardProfilePage';
import BikesPage from '../BikesPage';
import MissionsPage from '../MissionsPage';
import { useAuth0 } from '@auth0/auth0-react';
import { ThemeContextProvider, useThemeContext } from '../../libs/themeContext';

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
            <div style={theme}>
              <button onClick={loginWithRedirect}>Login to dashboard</button>
            </div>
          </Route>
        </Switch>
      </Router>
    </ThemeContextProvider>
  );
}

export default App;
