import './Root.css'
import {Outlet} from "react-router";

import { useMediaQuery } from 'react-responsive'
import React from "react";
export const Device = React.createContext('device');

const Root = () => {

    const isDesktop = useMediaQuery({ minWidth: 1024})

    const isTablet = useMediaQuery({ minWidth: 768, maxWidth : 1023})

    const isMobile = useMediaQuery({ maxWidth: 767 })



    return (
        <>
            <Device.Provider value={{isMobile : isMobile, isTablet : isTablet, isDesktop : isDesktop}}>
                <Outlet/>
            </Device.Provider>
        </>
    );
}

export default Root
