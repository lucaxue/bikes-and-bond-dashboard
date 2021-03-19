import styles from './DisplayMission.module.css';

function Mission({ mission, heading = '' }) {
  if (!mission) {
    return <p>Loading ...</p>;
  }
  const { name, location, difficulty, task } = mission;

  return (
    mission && (
      <div style={{ display: 'flex', flexDirection: 'column' }}>
        <h1>{heading}</h1>
        <div className={styles.flexContainer}>
          <div className={styles.titleContainer}>
            <div className={styles.titleText}>
              <h1>{name}</h1>
              <p>{location}</p>
            </div>
            <p>Difficulty: {difficulty}</p>
          </div>
          <div>
            <p>{task}</p>
          </div>
        </div>
      </div>
    )
  );
}

export default Mission;
