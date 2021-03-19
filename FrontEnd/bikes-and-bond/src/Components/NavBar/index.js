import { Link } from 'react-router-dom';
import { useThemeContext } from '../../libs/themeContext';

function NavBar() {
  const { toggleDark } = useThemeContext();
  return (
    <div>
      <nav>
        <h1>🕵️‍♀️ SPY DASHBOARD</h1>
        <Link to={`/Dashboard`}>Dashboard</Link>
        <Link to={`/missions`}>Missions</Link>
        <Link to={`/bikes`}>Bikes</Link>
        <button onClick={toggleDark}> Dark Mode </button>
      </nav>
    </div>
  );
}

export default NavBar;
