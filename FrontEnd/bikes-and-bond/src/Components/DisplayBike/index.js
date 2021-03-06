import styles from './DisplayBike.module.css';

function DisplayBike({ bike, heading = '' }) {
  if (!bike) {
    return <p>Loading ...</p>;
  }

  const { genre, title, author, colour } = bike;

  return (
    <div style={{ display: 'flex', flexDirection: 'column' }}>
      <h1>{heading}</h1>
      <div className={styles.flexContainer}>
        <h1>
          {title} by {author}
        </h1>
        <p className={styles.image}>🚲</p>
        <h2>Genre: {genre}</h2>
        <p>{colour}</p>
      </div>
    </div>
  );
}

export default DisplayBike;
