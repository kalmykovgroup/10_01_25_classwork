import ProductModel from "../model/ProductModel";

class HttpRequest{

    public static baseUrl : string = "https://localhost:7240";
    static Get(url : string, callBack: (arg0: any, httpStatusCode : number) => any){



        fetch(`${this.baseUrl}${url}`, {
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

export default HttpRequest;