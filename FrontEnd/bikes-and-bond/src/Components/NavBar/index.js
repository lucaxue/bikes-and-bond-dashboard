import { Link } from 'react-router-dom';
import { useThemeContext } from '../../libs/themeContext';

function NavBar() {
  const { toggleDark, isDarkMode } = useThemeContext();
  return (
    <div>
      <nav>
        <h1>🕵️‍♀️ SPY DASHBOARD</h1>
        <Link to={`/Dashboard`}>Dashboard</Link>
        <Link to={`/missions`}>Missions</Link>
        <Link to={`/bikes`}>Bikes</Link>
        <button onClick={toggleDark}> {isDarkMode ? '☀' : '🌛'}</button>
      </nav>
    </div>
  );
}

export default NavBar;
