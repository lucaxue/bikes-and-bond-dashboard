import useGet from '../../libs/useGet';
import { useAuth0 } from '@auth0/auth0-react';
import DisplayBike from '../DisplayBike';
import Profile from '../Profile';
import DisplayMission from '../DisplayMission';
import NavBar from '../NavBar';
import { useThemeContext } from '../../libs/themeContext';
import styles from './DashboardProfilePage.module.css';
import { useState } from 'react';

function DashboardProfilePage() {
  const { user, logout, isAuthenticated, isLoading } = useAuth0();

  const { theme } = useThemeContext();

  const [recommendedId, setRecommendedId] = useState(0);
  const updateRecommendedId = () => {
    const { max, round, random } = Math;

    let randomNum = 0;
    while (randomNum === recommendedId) {
      randomNum = max(0, round(random() * missions.length - 1));
    }
    setRecommendedId(randomNum);
  };

  const missions = useGet(`https://localhost:5001/missions`, [isAuthenticated]);
  const bikes = useGet(`https://localhost:5001/bikes`, [isAuthenticated]);

  if (isLoading || !bikes || !missions) {
    return <div>Loading ...</div>;
  }

  return (
    isAuthenticated && (
      <div style={theme}>
        <NavBar />
        <div className={styles.container}>
          <div className={styles.profile}>
            <Profile
              name={user.name}
              picture={user.picture}
              email={user.email}
              logout={logout}
            />
          </div>
          <div className={styles.recommend}>
            <DisplayBike
              bike={bikes[recommendedId]}
              heading={'Recommended Bike'}
            />
            <DisplayMission
              mission={missions[recommendedId]}
              heading={'Recommended Mission'}
            />
          </div>
          <button onClick={updateRecommendedId}>
            Get Another Set Of Recommendation!
          </button>
        </div>
      </div>
    )
  );
}

export default DashboardProfilePage;
