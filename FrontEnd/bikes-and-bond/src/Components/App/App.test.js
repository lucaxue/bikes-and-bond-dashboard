import { render } from '@testing-library/react';
import App from './';

test('button renders in app', () => {
  const { getByText } = render(<App />);
  const actual = getByText('Login to dashboard');
  expect(actual).toBeInTheDocument();
});
