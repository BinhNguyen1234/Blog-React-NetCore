import { ReactNode, useMemo } from 'react';
import Star from './Star';

export default function Frame({ index,fast }: { index: number, fast: boolean }) {
    const t = useMemo(() => {
        const t = [];
        for (let i = 0; i < 60; i++) {
            t.push(<Star key={i}></Star>);
        }
        return t;
    }, []);
    return <div className={`Galaxy Galaxy-frame${index} ${fast && "Fast"}`}>{t}</div>;
}
