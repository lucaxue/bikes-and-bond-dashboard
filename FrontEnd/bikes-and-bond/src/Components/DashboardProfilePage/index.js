import { Link } from 'react-router-dom';
import React from 'react';
import useGet from '../../libs/useGet';
import { Bikes, Missions } from '../../libs/sampleData';
import { useAuth0 } from '@auth0/auth0-react';
import DisplayRecommendedItem from '../DiplayRecommendedItem';

function DashboardProfilePage(props) {
  const { logout, user, isAuthenticated, isLoading } = useAuth0();

  const data = useGet('https://api.kanye.rest');
  console.log(data);

  if (isLoading) {
    return <div>Loading ...</div>;
  }

  return (
    isAuthenticated && (
      <>
        <div>
          <p>SPY DASHBOARD 🕵️‍♀️</p>
          <nav>
            <Link to={`/missions`}>Missions</Link>
            <Link to={`/bikes`}>Bikes</Link>
          </nav>
        </div>
        <h2>{user.name}</h2>
        <p>Email: {user.email}</p>
        <img src="https://bit.ly/3lvYepD" alt={user.name} />
        <button onClick={() => logout({ returnTo: window.location.origin })}>
          Logout
        </button>
        <DisplayRecommendedItem items={Bikes} variant={'bike'} />
        <DisplayRecommendedItem items={Missions} variant={'mission'} />
      </>
    )
  );
}

export default DashboardProfilePage;
