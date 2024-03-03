import { createBrowserRouter } from 'react-router-dom';
import SignUp from './SignUp/Signup.view.tsx';
import SignIn from './SignIn/Signin.view.tsx';
const router = createBrowserRouter([
    {
        path: '/',
        element: <SignIn />
    },
    {
        path: '/signin',
        element: <SignIn />
    },
    {
        path: '/signup',
        element: <SignUp />
    }
]);
export default router;
