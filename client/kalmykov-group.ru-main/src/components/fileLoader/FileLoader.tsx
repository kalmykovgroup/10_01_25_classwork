import HttpRequest from "../../api/HttpRequest";

class Work{
    src : string;
    callBack : (val : string) => {};

    constructor(src: string, callBack: (val : string) => {}) {
        this.src = src;
        this.callBack = callBack;
    }
}

class FileLoader {

    private static queue : Array<Work>  = [];

    private static isWorker = false;

    static async AddWorker(src : string, callBack : (val : string) => {}){
        this.queue.push(new Work(src, callBack));

        if(!this.isWorker){
            this.isWorker = true;
            await this.Load();
        }
    }

    static delay(millisecond: number) {
        return new Promise(resolve => {
            setTimeout(() => { resolve('') }, millisecond);
        })
    }

    private static async Load(){

           await this.delay(300);

            const work : Work = this.queue.shift();

            fetch(`${HttpRequest.baseUrl}${work.src}`, {
                method: 'GET',
                mode: 'cors',
            })
                .then((response) => response.blob())
                .then(blob => {

                    const src = URL.createObjectURL(blob);
                    work.callBack(src);
                    if(this.queue.length === 0){
                        this.isWorker = false;
                    }else{
                        this.Load()
                    }
                });

        }

}



export default FileLoader;
