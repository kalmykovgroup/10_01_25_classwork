import React, {useState} from 'react';
import {useAppDispatch, useAppSelector} from "../../hooks/hooks.ts";
import {logoutThunk} from "../../store/userSpace/authSlice.ts";
import ProductsContainer from "../../components/ProductsContainer/Container/ProductsContainer.tsx";
import {setAuthModalOpen} from "../../store/uiReducer.ts";
import {addNotification} from "../../store/notificationSlice.ts";

const Home: React.FC = () => {

    const [messageInformation, setMessageInformation] = useState("");

    const dispatch = useAppDispatch();
    const customer = useAppSelector((state) => state.auth.customer);

    const handleSendPhone = async () => {
        const result = await dispatch(logoutThunk()).unwrap();

        if(!result.success) {
            setMessageInformation(result.error ?? "");
        }
    };

    const showNotification = () => {
        dispatch(addNotification({ type: "success", message: "Операция выполнена успешно!" }));
    };

    return (
        <>
            <div>
                {customer
                    ? <>
                        <button onClick={handleSendPhone}>Выйти</button>
                    </>
                    : <>
                    <button onClick={() => dispatch(setAuthModalOpen(true))}>Войти</button>
                    </>
                }

            </div>

            {customer && <div>{customer.firstName ?? "User"}</div> }

            <div>{messageInformation}</div>
            <button onClick={showNotification}>Показать уведомление</button>;
            <h1>Главная страница</h1>
            <ProductsContainer/>
        </>
    );
};

export default Home;
