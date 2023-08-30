import App from '@components/App/App.tsx';
import { useSelector } from 'react-redux';
import { GlobalState } from 'src/store';
export default function HomeView() {
    const value = useSelector((state: GlobalState) => {
        return state.counter.value;
    });
    return <App value={value}></App>;
}
