import { useDispatch } from 'react-redux';
import { increment } from '@store/counter/counter.slice.ts';
import reactLogo from '@assets/react.svg';
import viteLogo from '/vite.svg';
import './App.style.css';
import.meta.env.VITE_APP_TITLE;
interface AppProps {
    value: number;
}
function App({ value }: AppProps) {
    const dispatch = useDispatch();
    console.log(import.meta.env);
    return (
        <>
            <div>
                <a href='https://vitejs.dev' target='_blank'>
                    <img src={viteLogo} className='logo' alt='Vite logo' />
                </a>
                <a href='https://react.dev' target='_blank'>
                    <img
                        src={reactLogo}
                        className='logo react'
                        alt='React logo'
                    />
                </a>
            </div>
            <h1>{import.meta.env.VITE_APP_TITLE}</h1>
            <div className='card'>
                <button
                    onClick={() => {
                        console.log(123);
                        dispatch(increment());
                    }}
                >
                    count is {value}
                </button>
                <p>
                    Edit <code>src/App.tsx</code> and save to test HMR
                </p>
            </div>
            <p className='read-the-docs'>
                Click on the Vite and React logos to learn more
            </p>
        </>
    );
}

export default App;
