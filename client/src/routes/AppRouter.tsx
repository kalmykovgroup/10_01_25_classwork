import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import Home from "../pages/Home/Home.tsx";
import UserProfile from "../pages/UserProfile/UserProfile.tsx";
import Cart from "../pages/Cart/Cart.tsx";
import Orders from "../pages/Orders/Orders.tsx";
import Favorites from "../pages/Favorites/Favorites.tsx";
import ProtectedRoute from "./ProtectedRoute";
import LoginModal from "../components/Common/Auth/LoginModal.tsx";
import {NotificationCenter} from "../components/Common/NotificationCenter/NotificationCenter.tsx";

const AppRouter = () => {
    return (
        <Router>
             <LoginModal/>
            <NotificationCenter/>
            <Routes>
                <Route path="/" element={<Home />}>
                    
                </Route>
                <Route path="/profile" element={<UserProfile />} />
                <Route path="/cart" element={<Cart />} />
                <Route path="/favorites" element={<Favorites />} />

                {/* Доступ к Orders только для авторизованных пользователей */}
                <Route path="/orders" element={<ProtectedRoute><Orders /></ProtectedRoute>} />

                {/* Если страница не найдена, редирект на Home */}
                <Route path="*" element={<Navigate to="/" />} />
            </Routes>
        </Router>
    );
};

export default AppRouter;
