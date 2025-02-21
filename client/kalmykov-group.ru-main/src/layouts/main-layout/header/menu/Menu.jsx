import styles from './Menu.module.css';
import {Component} from "react";
import PropTypes from "prop-types";

class Menu extends Component {

    state = {
        colorIcon : "#000000",
    }

    constructor(props) {
        super(props);
    }


    render()
    {
        return (
            <button className={styles.menu} onClick={() => this.props.clickMenu()}
                    onMouseEnter={() => this.setState({
                        colorIcon: "#ffffff"
                    })}
                    onMouseLeave={() => this.setState({
                        colorIcon: "#000000"
                    })}>


                <svg  id={styles['hamburger']} xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
                    <path className={`${styles.l1} ${this.props.isOpen ? styles.l1Transform : ""}`} d="M3 6h18v2H3z"></path>
                    <path className={`${styles.l2} ${this.props.isOpen ? styles.l2Transform : ""}`} d="M3 11h18v2H3z"></path>
                    <path className={`${styles.l3} ${this.props.isOpen ? styles.l3Transform : ""}`} d="M3 16h18v2H3z"></path>
                </svg>

                <div className={`${styles.label}`}>Каталог</div>

            </button>
        )
    }


}

Menu.propTypes = {
    clickMenu: PropTypes.func,
    isOpen: PropTypes.bool
};

export default Menu
