import styles from "./Product.module.css";
import ProductModel from "../../model/ProductModel.tsx";
import iconStar from './../../assets/product/starFill.svg';
import {useEffect, useState} from "react";
import FileLoader from "../fileLoader/FileLoader.tsx";




const Product = ({product}) => {

    const [mainImgSrc, setMainImgSrc] = useState(<img src="/src/assets/loader.svg" alt="loading"/>);
    const [isLoading, setIsLoading] = useState(true);

    const src = `${product.img.src}/${product.img.name}${product.img.extension}`

    useEffect(  () => {

        FileLoader.AddWorker(src, (src) => {

            setMainImgSrc(src)
            setIsLoading(false);
        }).then(undefined);



    }, [src, setIsLoading]);



    return (<div  className={styles.productItem}>

        <div className={styles.productContent}>
            <div className={styles.imgContainer}>
                <div className={styles.imgContainer__}>

                    <img className={styles.loaderSvg} src="/src/assets/loader.svg" style={{display: !isLoading ? "none" : undefined}} alt=""/>

                    <img className={styles.mainImg} src={mainImgSrc} alt="" loading={"lazy"}/>

                    <div className={styles.ratingContainer}>

                        <div className={styles.starContainer}>

                            <img
                                src={iconStar}
                                className={`${styles.imgStar}
                                     ${styles.smallStar}
                                     ${product.rating.value > 4 ? styles.middleStar : " "}
                                     ${product.rating.value > 4.7 ? styles.bigStar : " "}
                                 `}
                             alt="*"/>

                            <span>{product.rating.value}</span>
                        </div>

                        <div className={styles.messageContainer}>
                            <img className={styles.imgMessage} src="/src/assets/product/message.svg" alt="*"/>
                            {product.rating.numberOfReviews}
                        </div>


                    </div>
                </div>

            </div>

            <div className={styles.oneContainer}>


                <div className={styles.price}>
                    {product.price}₽
                    <div className={styles.oldPrice}>
                        {product.oldPrice}₽
                    </div>
                </div>


                <div className={styles.btnContainer}>
                    <div className={styles.btnContainer__w}>
                        <div className={styles.btnAddToCart}>
                            <img src="/src/assets/product/bagPlusFill.svg" alt=""/>
                        </div>
                    </div>

                </div>
            </div>
            <div className={`${styles.name}`}>
                <p>
                    <div  className={styles.imgIllusion}/>

                    {product.name}</p>
            </div>
        </div>

    </div>)
}

Product.propTypes = {
    product: ProductModel
};

export default Product;