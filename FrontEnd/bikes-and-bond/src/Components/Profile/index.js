function Profile({ name, email, picture, logout }) {
  return (
    <div>
      <h2>{name}</h2>
      <p>Email: {email}</p>
      <img src={picture} alt={name} />
      <button onClick={() => logout({ returnTo: window.location.origin })}>
        Logout
      </button>
    </div>
  );
}

export default Profile;
