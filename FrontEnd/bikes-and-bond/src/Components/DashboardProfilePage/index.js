import React from 'react';
import { Link } from 'react-router-dom';
import { useAuth0 } from '@auth0/auth0-react';

const imgLink =
  'https://lh3.googleusercontent.com/-MvNn79P5fHI/YFSBKS18WaI/AAAAAAAAABA/wUN1xE-vSFo5e6Gc8Im2bOhgk2c7qWkHgCEwYBhgLKtQDAL1OcqzBCGRVNeIg_AQzc56hliP5KHq5k47ViCxHCN32wYugLwGDxjiHsxsRuFGbO8Xqf4T5zrZk6zSRAElYXTbrye0zl9fxJh_RJFBPnTtZ8JFwhmYG44D0s94cuHwGR3YHUjLYLyDapCnm8WKl0BanPKb8gzYCSG8WBMnKLy6Kczbphmwua7WYn4NXLWcXbNcIFa-k93aiN8BLDtjk_4LnVHgJ4nfgofsF2TmaefzZkUP3MQM1zROZBTlFIbQscDdvNsv3a5eKk5HQcG1veDMslOw1C_8iFxZKc7PDqM697GAG1SjqDNrdls6B7CqzUxzICoSkeuWX3wmc6_1UksBw3Ljzuoil00fyDcRLGebEbvb9fnumtgZrLweHyvd4sKY4AwAsd6y1mjyedBlO_7nHH_Iuy6K0SJpGnndR4Qk7zm1-x85_7aH3Xsbrz-GIhWh68w1pbZZhYPdg6AAwAbDdB9Y6brcSZBJAuqdKwUDTZv7H3N8O-13fJXcsqWzBrEe8D1GmVjHikRkQj7Z4NNkF-0n-n-XFv0yWbyeMt0chWmTpIBIPzhJMHMOgV72dnc2uQnSLicdnqxCEfV4M1l3abwKHDBVuHFhZo_FbMXONU2gOMOak0oIG/w139-h140-p/wmi23qe3doh41.jpeg';

function DashboardProfilePage(props) {
  const { logout, user, isAuthenticated, isLoading } = useAuth0();

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
        <img src={imgLink} alt={user.name} />
        <button onClick={() => logout({ returnTo: window.location.origin })}>
          Logout
        </button>
      </>
    )
  );
}

export default DashboardProfilePage;
