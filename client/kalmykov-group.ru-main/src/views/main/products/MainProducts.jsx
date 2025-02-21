import {useContext, useEffect, useState} from "react";
import Product from "../../../components/product/Product.jsx";
import styles from "./MainProducts.module.css"
import ProductRequest from "../../../api/ProductRequest.tsx";
import {Device} from "../../../layouts/Root.jsx";

function MainProducts() {

    const device = useContext(Device);

    const [products, setProducts] = useState([]);

    useEffect(() => {

        ProductRequest.GetPage(1, (data , httpStatusCode) => {

            if(httpStatusCode === 200){
                setProducts(data)
            }else{
                console.log(httpStatusCode);
            }
        })



    }, []);

   return (
       <div className={styles.productContainer}>
           {
               products.map((product) =>
                   <>
                         <Product product={product}/>
                    </>
               )
           }
       </div>
   )

}

export default MainProducts;
