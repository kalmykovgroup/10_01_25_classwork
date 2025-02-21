import ProductModel from "../model/ProductModel";
import HttpRequest from "./HttpRequest";


class ProductRequest{

    private static urlGetPage: string = "https://localhost:7240/product/page/"

    static GetPage(page : number, callBack: (arg0: Array<ProductModel>, httpStatusCode : number) => any){

        HttpRequest.Get(`/product/page/${page}`, (data: Array<ProductModel>, httpStatusCode : number) => {

            const array : Array<ProductModel> = [];

            for(let object of data){
                array.push(new ProductModel(
                    object.id,
                    object.category,
                    object.unit,
                    object.rating,
                    object.img,
                    object.name,
                    object.price,
                    object.oldPrice,
                ));
            }

            callBack(array, httpStatusCode);

        })


    }

    static GetProduct(id : number, callBack: (arg0: Array<ProductModel>, httpStatusCode : number) => any){

        fetch(`https://localhost:7240/product/${id}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            mode: 'cors',
        })
            .then((response) => response.json())
            .then(data => callBack(data, 200));
    }

}

export default ProductRequest;


