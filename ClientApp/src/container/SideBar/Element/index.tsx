import { ReactElement } from 'react';

interface sideBarElementProps {
    childrens: ReactElement[] | null;
    textContent: string;
}

function SideBar({ childrens, textContent }: sideBarElementProps) {
    return (
        <>
            <ul>
                {textContent}
                {childrens}
            </ul>
        </>
    );
}

export default SideBar;
