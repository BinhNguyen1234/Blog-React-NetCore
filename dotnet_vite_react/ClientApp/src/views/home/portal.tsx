/* eslint-disable @typescript-eslint/no-explicit-any */
import { useState } from 'react';
import { createPortal } from 'react-dom';

export default function Mod() {
    const [state, setState] = useState(true);
    function T() {
        return (
            state && (
                <div>
                    <TTTT></TTTT>
                </div>
            )
        );
    }
    
    return [T as any, setState];
}
function TTTT() {
    return createPortal(
        <div>Proádasdasdasdasdasdtal</div>,
        document.getElementById('test-portal') as HTMLElement
    );
}
