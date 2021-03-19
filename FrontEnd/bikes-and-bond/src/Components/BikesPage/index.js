import React, { useState } from 'react';
import useGet from '../../libs/useGet';
import NavBar from '../NavBar';
import styles from './BikesPage.module.css';
import DisplayBike from '../DisplayBike';
import { useThemeContext } from '../../libs/themeContext';

function BikesPage() {
  const { theme } = useThemeContext();
  const [search, setSearch] = useState('');

  const url = `https://localhost:5001/bikes?search=${search}`;
  const bikes = useGet(url, [search]);

  if (!bikes) {
    return <p>loading</p>;
  }

  return (
    <div style={theme}>
      <NavBar />
      <div className={styles.container}>
        <h1>Bikes</h1>
        <input
          className="Bikes Box"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />
        <div>
          {bikes.map((bike) => {
            return <DisplayBike bike={bike} />;
          })}
        </div>
      </div>
    </div>
  );
}

export default BikesPage;
