import styles from './DisplayBike.module.css';

function DisplayBike({ bike, heading = '' }) {
  const { genre, title, author, colour } = bike;
  return (
    <>
      <h1>{heading}</h1>
      <div className={styles.flexContainer}>
        <h1>
          {title} by {author}
        </h1>
        <p className={styles.image}>🚲</p>
        <h2>Genre: {genre}</h2>
        <p>{colour}</p>
      </div>
    </>
  );
}

export default DisplayBike;
