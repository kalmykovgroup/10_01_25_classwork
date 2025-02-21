import React from "react";

import styles from "./Favourites.module.css"
import common from "../../Header/Common.module.css";
import {Link} from "react-router-dom";
import favouritesIcon from "../../../assets/images/favourites.svg";

interface FavouritesProps {
    className?: string
}

const Favourites: React.FC<FavouritesProps> = ({className}: FavouritesProps) => {

    return <>
        <Link className={`${className} ${styles.favourites} ${common.header_right_item}`} to={`/favourites`}>
            <img src={favouritesIcon} className={styles.favouritesIcon} alt="Favourites"/>
            <span>Избранное</span>
        </Link>
    </>
}

export default Favourites;