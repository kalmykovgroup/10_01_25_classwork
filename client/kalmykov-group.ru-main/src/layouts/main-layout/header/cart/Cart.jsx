import styles from './Cart.module.css';
import common from './../Common.module.css';
import cartIcon from '/src/assets/cart.svg'
import {Link} from "react-router-dom";
function Cart() {

    return (
        <Link  className={`${styles.cart} ${common.header_right_item}`}  to={`/cart`}>
            <img src={cartIcon} className={styles.cartIcon} alt="cart"/>
            <span>Корзина</span>
        </Link>
    )
}

export default Cart
