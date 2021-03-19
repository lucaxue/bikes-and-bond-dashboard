import styles from "./DisplayMission.module.css";

function Mission({ mission }) {
  const { name, location, difficulty, task } = mission;

  return (
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
  );
}

export default Mission;
