import './Content.css'
import {Outlet} from "react-router";

 const Content = () => {


    return (
        <div className="content">
            <Outlet/>
        </div>
    )
};

export default Content
