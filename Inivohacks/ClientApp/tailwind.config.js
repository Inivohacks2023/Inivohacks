/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        'regal-blue': '#243c5a',
      },
      scale: {
        '132': '1.32',
      },
      borderRadius: {
        'lg': '10px',
      },
      boxShadow: {
        'login': '0px 4px 4px 0px rgba(0, 0, 0, 0.25);',
      }
},
  },
  plugins: [],
}

