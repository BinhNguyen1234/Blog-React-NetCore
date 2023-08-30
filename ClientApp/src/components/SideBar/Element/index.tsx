import { ReactElement } from 'react';

interface sideBarElementProps {
  childrens: ReactElement[] | ReactElement | null;
  textContent: string;
}

function SideBarElement({ childrens, textContent }: sideBarElementProps) {
  const WrappedChildre = Array.isArray(childrens) ? (
    childrens.map((child) => {
      return <li>{child}</li>;
    })
  ) : (
    <li>{childrens}</li>
  );
  return (
    <>
      <ul>
        {textContent}
        {WrappedChildre}
      </ul>
    </>
  );
}

export default SideBarElement;
