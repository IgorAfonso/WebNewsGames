import type { Config } from "tailwindcss";

const config: Config = {
  content: [
    "./app/**/*.{js,ts,jsx,tsx}",
    "./pages/**/*.{js,ts,jsx,tsx}",
    "./components/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: "#1e40af", // bg-blue-900
        accent: "#2563eb", // bg-blue-600
        hoverBlue: "#93c5fd", // hover:text-blue-300
        lightGray: "#f3f4f6", // bg-gray-100
        darkGray: "#4b5563", // text-gray-600
        hoverDarkBlue: "#1d4ed8", // hover:bg-blue-700
        grey: "#999999",
      },
      fontFamily: {
        sans: ["Arial", "sans-serif"],
      },
    },
    screens: {
      sm: "640px",
      md: "768px",
      lg: "1024px",
      xl: "1280px",
      "2xl": "1536px",
    },
  },
  plugins: [],
};

export default config;
