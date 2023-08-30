import { ReactElement } from 'react';

interface sideBarProps {
  children: ReactElement[] | ReactElement |null;
}

function SideBar({children}: sideBarProps) {
    const wrappedChildrens= children?.map(child => { return <li>{child}</li>; });
  return (
    <>
      <ul>{wrappedChildrens}</ul>
    </>
  );
}

export default SideBar;
