/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable @typescript-eslint/no-unused-vars */
import Mod from './portal';
import SideBarContainer from 'src/container/SideBar/SideBar.tsx';
export default function HomeView() {
    const [T1, set1] = Mod();
    const [T2, set2] = Mod();

    return (
        <>
            <T1></T1>
            <T2></T2>
            <button
                onClick={() => {
                    set1((x: any) => {
                        return !x;
                    });
                }}
            >
                11
            </button>
            <button
                onClick={() => {
                    set2((x: any) => {
                        return !x;
                    });
                }}
            >
                22
            </button>
            <SideBarContainer />
        </>
    );
}
