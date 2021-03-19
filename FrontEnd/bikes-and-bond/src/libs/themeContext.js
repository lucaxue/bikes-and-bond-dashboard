import { useState, createContext, useContext } from 'react';
import { theme } from './theme';

const ThemeContext = createContext({
  theme: null,
  toggleDark: null,
  isDarkMode: null,
});

export function ThemeContextProvider({ children }) {
  const [isDarkMode, setIsDarkMode] = useState(true);

  return (
    <ThemeContext.Provider
      value={{
        theme: theme[isDarkMode ? 'dark' : 'light'],
        toggleDark: () => {
          setIsDarkMode(!isDarkMode);
        },
        isDarkMode: isDarkMode,
      }}
    >
      {children}
    </ThemeContext.Provider>
  );
}

export const useThemeContext = () => useContext(ThemeContext);
