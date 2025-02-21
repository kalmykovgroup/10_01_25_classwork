class CategoryModel {
    id : number;
    name: string;
    Parent : CategoryModel;

    constructor(id: number, name: string, Parent: CategoryModel) {
        this.id = id;
        this.name = name;
        this.Parent = Parent;
    }
}

export default CategoryModel;