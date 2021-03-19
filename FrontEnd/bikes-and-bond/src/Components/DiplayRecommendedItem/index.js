function DisplayRecommendedItem({ items, variant }) {
  const item = items[Math.round(Math.random() * items.lenght)];
  return <div>{item}</div>;
}

export default DisplayRecommendedItem;
