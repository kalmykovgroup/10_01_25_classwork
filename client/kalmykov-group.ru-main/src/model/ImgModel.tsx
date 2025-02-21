

class ImgModel {
    id : number;
    src: string;
    name: string;
    extension: string;
    size: number;


    constructor(id: number, src: string, name: string, extension: string, size: number) {
        this.id = id;
        this.src = src;
        this.name = name;
        this.extension = extension;
        this.size = size;
    }
}

export default ImgModel;