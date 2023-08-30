import { createBrowserRouter } from 'react-router-dom';
import HomeView from './home/home.view.tsx';
const router = createBrowserRouter([
    {
        path: '/',
        element: <HomeView />
    },
    {
        path: '/home',
        element: <HomeView />
    }
]);
export default router;
