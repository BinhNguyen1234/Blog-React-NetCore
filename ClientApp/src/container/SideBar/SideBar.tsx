import SideBar from '@components/SideBar/index';
import {  Button } from '@mui/base';
function SideBarContainer() {
    return (
        <>
            <SideBar>
                <Button className='text-3xl font-bold underline text-center'>
                    <div>1</div>
                </Button>

                <Button>
                    <div>2</div>
                </Button>
            </SideBar>
        </>
    );
}

export default SideBarContainer;
