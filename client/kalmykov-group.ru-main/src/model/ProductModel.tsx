import CategoryModel from "./CategoryModel";
import UnitModel from "./UnitModel";
import RatingModel from "./RatingModel";
import ImgModel from "./ImgModel";

class ProductModel {

    public id : number;
    public category : CategoryModel;
    public unit : UnitModel;
    public rating : RatingModel;
    public img : ImgModel;


    public name : string;
    public price : number;
    public oldPrice : number;


    constructor(id: number, category: CategoryModel, unit: UnitModel, rating: RatingModel, img: ImgModel, name: string, price: number, oldPrice: number) {
        this.id = id;
        this.category = category;
        this.unit = unit;
        this.rating = rating;
        this.img = img;
        this.name = name;
        this.price = price;
        this.oldPrice = oldPrice;
    }
}

export default ProductModel;