import SideBar from '@components/SideBar/index';
import {  Button } from '@mui/base';
function SideBarContainer() {
    return (
        <>
            <SideBar>
                <Button className='bg-green-600 rounded-md py-1 px-4...'>
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
