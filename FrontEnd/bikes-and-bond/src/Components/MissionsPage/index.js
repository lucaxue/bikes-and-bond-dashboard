import React, { useState } from 'react';
import useGet from '../../libs/useGet';
import NavBar from '../NavBar';
import Mission from '../DisplayMission';
import { useThemeContext } from '../../libs/themeContext';
import styles from './MissionsPage.module.css';

function MissionsPage() {
  const { theme } = useThemeContext();
  const [search, setSearch] = useState('');

  const url = `https://localhost:5001/missions?search=${search}`;
  const missions = useGet(url, [search]);

  if (!missions) {
    return <p>loading</p>;
  }

  return (
    <div style={theme}>
      <NavBar />
      <div className={styles.container}>
        <h1>Missions</h1>
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
    </div>
  );
}

export default MissionsPage;
