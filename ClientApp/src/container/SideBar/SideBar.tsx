import SideBar from '@components/SideBar/index';
import SideBarElement from '@components/SideBar/Element/index'; 

function SideBarContainer() {
    return (
        <>
            <SideBar>
                <SideBarElement>
                    <div>1</div>
                </SideBarElement>

                <SideBarElement>
                    <div>2</div>
                </SideBarElement>
            </SideBar>
        </>
    );
}

export default SideBarContainer;
