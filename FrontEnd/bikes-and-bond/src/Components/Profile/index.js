import styles from "./Profile.module.css";

function Profile({ name, email, picture, logout }) {
  return (
    <div className={styles.profile}>
      <img src={picture} alt={name} className={styles.image} />
      <div className={styles.textProfile}>
        <h2>{name}</h2>
        <p>Email: {email}</p>
      </div>

      <button
        className={styles.button}
        onClick={() => logout({ returnTo: window.location.origin })}
      >
        Logout
      </button>
    </div>
  );
}

export default Profile;
