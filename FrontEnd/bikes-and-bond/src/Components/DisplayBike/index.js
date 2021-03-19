function DisplayBike({ bike }) {
  const { Id, Genre, Title, Author, Colour } = bike;
  return (
    <div>
      <h1>
        {Id}: {Title} by {Author}
      </h1>
      <h2>Genre: {Genre}</h2>
      <p>{Colour}</p>
    </div>
  );
}

export default DisplayBike;
