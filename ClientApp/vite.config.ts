import { defineConfig } from "vite";
import react from "@vitejs/plugin-react-swc";
import basicSsl from "@vitejs/plugin-basic-ssl";

const PORT_FOR_PROXY = process.env.ASPNETCORE_HTTPS_PORT;
export default defineConfig({
  plugins: [react(), basicSsl()],
  server: {
    https: true,
    proxy: {
      "/api": {
        target: `https://localhost:${PORT_FOR_PROXY}`,
        secure: false,
      },
    },
  },
  resolve: {
    extensions: [".vue", ".svg"],
    alias: [
      { find: "@assets", replacement: "/src/assets" },
      { find: "@view", replacement: "/src/view" },
    ],
  },
});
