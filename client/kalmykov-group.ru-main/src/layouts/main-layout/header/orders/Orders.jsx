 import styles from './Orders.module.css';
import common from './../Common.module.css';

import ordersIcon from '/src/assets/orders.svg'
import {Link} from "react-router-dom";



function Orders() {

    return (
        <Link  className={`${styles.orders} ${common.header_right_item}`}  to={`/orders`}>
            <img src={ordersIcon} className={styles.ordersIcon} alt="orders"/>
            <span>Заказы</span>
        </Link>
)
}

export default Orders
