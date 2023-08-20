import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react-swc';
import basicSsl from '@vitejs/plugin-basic-ssl';
import tsconfig from './tsconfig.json';

const aliasFromTsConfig = Object.entries(tsconfig.compilerOptions.paths);
const aliasForVite = aliasFromTsConfig.map((e) => {
  return {
    find: e[0].replace(/\/\*$/, ''),
    replacement: e[1][0].replace(/\/\*$/, '')
  };
});
console.log(aliasForVite);
const PORT_FOR_PROXY = process.env.ASPNETCORE_HTTPS_PORT;
export default defineConfig({
  plugins: [react(), basicSsl()],
  server: {
    https: true,
    proxy: {
      '/api': {
        target: `https://localhost:${PORT_FOR_PROXY}`,
        secure: false
      }
    }
  },
  base: './',
  resolve: {
    extensions: ['.ts', '.tsx', '.slice','.svg'],
    
    alias: aliasForVite
  }
});
