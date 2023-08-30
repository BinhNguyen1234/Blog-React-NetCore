import { ReactElement, useMemo } from 'react';

interface sideBarProps {
    children: ReactElement[] | null;
}

function SideBar({ children }: sideBarProps) {
    const wrappedChildrens = useMemo(
        () =>
            children?.map((child) => {
                return <li>{child}</li>;
            }),
        [children]
    );
    return (
        <>
            <ul>{wrappedChildrens}</ul>
        </>
    );
}

export default SideBar;
