import { useState, createContext, useContext } from 'react';
import { theme } from './theme';

const ThemeContext = createContext(null);

export function ThemeContextProvider({ children }) {
  const [isDarkMode, setIsDarkMode] = useState(true);

  return (
    <ThemeContext.Provider
      value={{
        theme: theme[isDarkMode ? 'dark' : 'light'],
        toggleDark: () => {
          setIsDarkMode(!isDarkMode);
        },
      }}
    >
      {children}
    </ThemeContext.Provider>
  );
}

export const useThemeContext = () => useContext(ThemeContext);
