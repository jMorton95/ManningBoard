/** @type {import('tailwindcss').Config} */

module.exports = {
  content: ["./src/**/*.{js,ts,jsx,tsx}", "./pages/**/*.{js,ts,jsx,tsx}"],
  theme: {
    fontFamily: {
      sans: ['Graphik', 'sans-serif'],
      serif: ['Merriweather', 'serif'],
    },
    extend: {
      colors: {
        'custom-dark': {
          '100': '#131313',
          '200': '#191919',
          DEFAULT: '#222222',
          '300': '#222222',
          '400': '#2A2A2A',
          '500': '#323131'
        },
        'custom-main': {
          '100': '#FC9526',
          DEFAULT: '#FCB126',
          '200': '#FCB126',
          '300': '#FCC526',
          '400': '#FCD726',
          '500': '#FCEA26'
        }
      },
      gridTemplateRows: {
        'layout': '3rem 1fr 2rem'
      }
    },
  },
  plugins: [],
}