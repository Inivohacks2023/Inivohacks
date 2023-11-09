/** @type {import('tailwindcss').Config} */
module.exports = {
  important: true,
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        'regal-blue': '#7FD3FA',
      },
      scale: {
        '132': '1.32',
      },
      borderRadius: {
        'lg': '10px',
      },
      boxShadow: {
        'login': '0px 4px 4px 0px rgba(0, 0, 0, 0.25);',
      },
      backgroundImage: {
        'login-bg': "url('./assets/images/bg-login.png')",
      }
},
  },
  plugins: [],
}

