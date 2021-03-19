import { Link } from 'react-router-dom';
import useGet from '../../libs/useGet';
import { Bikes, Missions } from '../../libs/sampleData';
import { useAuth0 } from '@auth0/auth0-react';
import DisplayBike from '../DisplayBike';
import Profile from '../Profile';
import DisplayMission from '../DisplayMission';

function DashboardProfilePage(props) {
  const { user, logout, isAuthenticated, isLoading } = useAuth0();

  //const data = useGet('https://api.kanye.rest');
  //console.log(data);

  if (isLoading) {
    return <div>Loading ...</div>;
  }

  return (
    isAuthenticated && (
      <>
        
        <Profile
          name={user.name}
          picture={user.picture}
          email={user.email}
          logout={logout}
        />
        <DisplayBike bike={Bikes[0]} heading={'Recommended Bike'} />
        <DisplayMission mission={Missions[0]} heading={'Recommended Mission'} />
      </>
    )
  );
}

export default DashboardProfilePage;
