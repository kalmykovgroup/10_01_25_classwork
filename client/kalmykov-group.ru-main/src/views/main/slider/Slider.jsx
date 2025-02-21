
import s from "./Slider.module.css"
import {useEffect, useState} from "react";
import FileLoader from "../../../components/fileLoader/FileLoader.tsx";

const Slider = () => {

    const [src, setSrc] = useState(<img src="/src/assets/loader.svg" alt="loading"/>);
    const [isLoading, setIsLoading] = useState(true);

    const path = "/source/advertisement/6c282bc7-91e8-4bee-80cc-5ecc6b57b4e5/home.jpg";



    useEffect(  () => {


        FileLoader.AddWorker(path, (src) => {

            setSrc(src)
            setIsLoading(false);
        }).then(undefined);



    }, [path, setIsLoading]);

    return (
        <div className={s.sliderContainer}>

            <img className={s.loaderSvg} src="/src/assets/loader.svg"
                 style={{display: !isLoading ? "none" : undefined}} alt=""/>

            <img className={s.advertisement} src={src} alt="" loading={"lazy"}/>

        </div>
    )
}

export default Slider
