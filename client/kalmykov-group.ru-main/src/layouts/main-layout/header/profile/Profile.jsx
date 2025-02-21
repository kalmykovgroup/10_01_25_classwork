import styles from './Profile.module.css';
import common from './../Common.module.css';
import profileIcon from '/src/assets/profile.svg'
import {Link} from "react-router-dom";

function Profile() {
    return (
        <Link  className={`${styles.profile} ${common.header_right_item}`}  to={`/profile`}>
            <img src={profileIcon} className={styles.profileIcon} alt="profile"/>
            <span className={styles.label}>Аккаунт</span>
        </Link>
    )
}

export default Profile
