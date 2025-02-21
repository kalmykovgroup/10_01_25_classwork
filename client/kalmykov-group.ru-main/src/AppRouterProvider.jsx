import {RouterProvider} from "react-router";
import {createBrowserRouter, createRoutesFromElements, Route} from "react-router-dom";
import MainLayout from "./layouts/main-layout/MainLayout.jsx";
import Main from "./views/main/Main.jsx";
import About from "./views/about/About.jsx";
import AdminLayout from "./layouts/admin-layout/AdminLayout.jsx";
import Root from "./layouts/Root.jsx";

const appRouterProvider = createBrowserRouter(
    createRoutesFromElements(
        <>
            <Route path="/" element={<Root/>}>

                <Route path="/" element={<MainLayout/>}>
                    <Route index path="/" element={<Main/>}></Route>
                    <Route path="about" element={<About/>}></Route>
                </Route>

                <Route path="/admin" element={<AdminLayout/>}></Route>
            </Route>
        </>
    )
)

function  AppRouterProvider () {

    return (
        <>
            <RouterProvider router={appRouterProvider}/>
        </>
    );
}

export default AppRouterProvider