import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import mkcert from 'vite-plugin-mkcert'
import path from "path"

export default defineConfig({
  plugins: [react(), mkcert()],
  server: {
    https: true,
    port: 7002,
  },
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
  },
  envDir : "./environments/"
})
