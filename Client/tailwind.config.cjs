/** @type {import('tailwindcss').Config} */

module.exports = {
  darkMode: ["class"],
  content: ["./src/**/*.{js,ts,jsx,tsx}", "./pages/**/*.{js,ts,jsx,tsx}"],
  theme: {
    fontFamily: {
      sans: ['Graphik', 'sans-serif'],
      serif: ['Merriweather', 'serif'],
    },
    container: {
      center: true,
      padding: "2rem",
      screens: {
        "2xl": "1400px",
      },
    },
    extend: {
      colors: {
        'custom-dark': {
          '100': '#131313',
          '200': '#191919',
          DEFAULT: '#222222',
          '300': '#222222',
          '400': '#2A2A2A',
          '500': '#323131',
          '600': '#3D3C3C',
          '700': '#474646',
          '800': '#525050',
          '900': '#5C5A5A'
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
        'layout': '4rem 1fr',
        'layout-old': '4rem 1fr 3rem'
      },
      keyframes: {
        "accordion-down": {
          from: { height: 0 },
          to: { height: "var(--radix-accordion-content-height)" },
        },
        "accordion-up": {
          from: { height: "var(--radix-accordion-content-height)" },
          to: { height: 0 },
        },
      },
      animation: {
        "accordion-down": "accordion-down 0.2s ease-out",
        "accordion-up": "accordion-up 0.2s ease-out",
      },
      grayscale: {
        50: '50%',
      },
      transitionDuration: {
        3000: '3000ms',
      }
    },
  },
  plugins: [require("tailwindcss-animate")],
}