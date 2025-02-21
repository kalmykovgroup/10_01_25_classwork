
import styles from './Main.module.css'
import Slider from "./slider/Slider.jsx";
import MainProducts from "./products/MainProducts.jsx";

function Main() {


    return (
       <div className={styles.main}>
           <div className={styles.sliderContainer}>
               <Slider/>
           </div>

            <div className={styles.productContainer}>
                <MainProducts/>
            </div>

       </div>
    )
}

export default Main
