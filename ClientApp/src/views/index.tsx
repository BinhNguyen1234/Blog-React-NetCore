import { createBrowserRouter } from 'react-router-dom';
import App from './home/App.tsx';
const router = createBrowserRouter([
  {
    path: '/',
    element: <App />
  }
]);
export default router;
