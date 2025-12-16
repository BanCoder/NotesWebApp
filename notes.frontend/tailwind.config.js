/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  // Отключить стандартные стили, чтобы не конфликтовали с Chakra
  corePlugins: {
    preflight: false, // Очень важно!
  },
  theme: {
    extend: {},
  },
  plugins: [],
}