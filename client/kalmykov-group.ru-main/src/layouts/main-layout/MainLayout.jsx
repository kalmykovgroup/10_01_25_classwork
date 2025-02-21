import './MainLayout.css'
import Header from "./header/Header.jsx";
import Content from "./content/Content.jsx";
import Footer from "./footer/Footer.jsx";
import {Component} from "react";

class MainLayout extends Component {

    constructor(props) {
        super(props);

    }


    render() {

        return(
            <>
                <Header/>
                <Content/>
                <Footer/>

            </>
        );
    }
}

export default MainLayout;





