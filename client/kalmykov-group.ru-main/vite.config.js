import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  css: {
    modules: true,
  },
  test: {
    // 👋 add the line below to add jsdom to vite
    environment: 'jsdom',
    // hey! 👋 over here
  //  globals: true,
    //setupFiles: './tests/setup.js', // предполагая, что тестовая папка находится в корневом каталоге нашего проекта
  }
})






