

class RatingModel {
    id : number;
    value: number;
    numberOfReviews : number;


    constructor(id: number, value: number, numberOfReviews: number) {
        this.id = id;
        this.value = value;
        this.numberOfReviews = numberOfReviews;
    }
}

export default RatingModel;