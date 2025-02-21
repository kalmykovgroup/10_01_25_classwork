import styles from './Favourites.module.css';
import common from './../Common.module.css';
import favouritesIcon from '/src/assets/favourites.svg'
import {Link} from "react-router-dom";
function WishList() {

    return (
        <Link  className={`${styles.favourites} ${common.header_right_item}`}  to={`/favourites`}>
            <img src={favouritesIcon} className={styles.favouritesIcon} alt="WishList"/>
            <span>Избранное</span>
        </Link>
    )
}

export default Favourites
