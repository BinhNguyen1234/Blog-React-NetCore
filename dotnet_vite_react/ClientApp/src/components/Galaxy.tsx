import { useMemo } from 'react';
import Frame from './Frames';

export default function Galaxy({fast}: {fast: boolean}) {
    const Frames = useMemo(() => {
        const t = [];
        for (let i = 0; i < 3; i++) {
            t.push(<Frame key={i} fast={fast} index={i}></Frame>);
        }
        return t;
    }, [fast]);
    return (
        <div
            style={{
                overflow: 'hidden',
                width: '100%',
                height: '100%',
                position: 'absolute'
            }}
        >
            {Frames}
        </div>
    );
}
