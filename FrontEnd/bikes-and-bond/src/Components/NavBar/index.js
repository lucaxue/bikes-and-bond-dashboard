import { Link } from "react-router-dom";
import { useThemeContext } from "../../libs/themeContext";
import styles from "./NavBar.module.css";

function NavBar() {
  const { toggleDark, isDarkMode } = useThemeContext();
  return (
    <div className={styles.navFlex}>
      <div className={styles.innerFlex}>
        <div>
          <h1>🕵️‍♀️ SPY DASHBOARD</h1>
        </div>
        <div className={styles.linkFlex}>
          <Link className={styles.links} to={`/Dashboard`}>
            Dashboard
          </Link>
          <Link className={styles.links} to={`/missions`}>
            Missions
          </Link>
          <Link className={styles.links} to={`/bikes`}>
            Bikes
          </Link>
          <button onClick={toggleDark}> {isDarkMode ? "☀" : "🌛"}</button>
        </div>
      </div>
    </div>
  );
}

export default NavBar;
