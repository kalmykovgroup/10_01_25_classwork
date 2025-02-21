import React, {useState, useEffect} from "react";
import {useAppDispatch, useAppSelector} from "../../../hooks/hooks.ts";
import {
    loginThunk,
    resetError,
    back,
    verifyPhoneCodeThunk,
    setIsSentCode
} from "../../../store/userSpace/authSlice.ts";

import styles from "./LoginModal.module.css";
import {setAuthModalOpen} from "../../../store/uiReducer.ts";

const LoginModal: React.FC = () => {
    const dispatch = useAppDispatch();
    const isOpen = useAppSelector((state) => state.ui.authModalOpen);

    const [scrollbarWidth, setScrollbarWidth] = useState(0);

    // ✅ Загружаем номер телефона из localStorage (или оставляем пустым)
    const [phone, setPhone] = useState("+79260128187");
    const [code, setCode] = useState("")

    const [remainingSeconds, setRemainingSeconds] = useState<number>(0);
    const [isFoundUnblockingPair, setIsFoundUnblockingPair] = useState<boolean>(false);


    // Достаём из Redux нужные значения
    const {
        isLoading,
        unblockingPairs,
        isSentCode,
        customer,
        error
    } = useAppSelector((state) => state.auth);


    const navEnterCode = () =>{
        dispatch(setIsSentCode(true))
    }

    // Отправка номера телефона для получения кода
    const handleSendPhone = async (e: React.FormEvent) => {
        e.preventDefault();
        dispatch(resetError())
        dispatch(loginThunk({phoneNumber: phone}));
    };

    const closeModal = () => {
        dispatch(resetError());  // Очистка ошибки в Auth
        dispatch(setAuthModalOpen(false)); // Закрытие модалки в UI

    };
    useEffect(() => {
        if(customer != null){
            closeModal()
        }
    })

    const handleVerifyPhoneCode = async (e: React.FormEvent) => {
        e.preventDefault();
        await dispatch(verifyPhoneCodeThunk({ phoneNumber: phone, code: code }));
    }

    //Это нужно для корректного отображения
    useEffect(() => {
        const updateScrollbarWidth = () => {
            const width = window.innerWidth - document.documentElement.clientWidth;

            setScrollbarWidth(width);
        };

        if (isOpen) {
            updateScrollbarWidth();
            document.body.style.overflow = "hidden";
            document.body.style.paddingRight = `${scrollbarWidth}px`;

        } else {
            document.body.style.overflow = "auto";
            document.body.style.paddingRight = "0";
        }

        return () => {
            document.body.style.overflow = "auto";
            document.body.style.paddingRight = "0";
        };
    }, [isOpen, scrollbarWidth]);




    useEffect(() => {
        const foundPair = unblockingPairs.find((pair) => pair.phoneNumber === phone);
        if (foundPair && foundPair.unblockingTime) {

            setIsFoundUnblockingPair(true);

            const updateRemainingTime = () => {
                const currentSeconds = Math.floor(Date.now() / 1000) - Math.floor(new Date("1980-01-01T00:00:00Z").getTime() / 1000);
                const difference = foundPair.unblockingTime - currentSeconds;
                setRemainingSeconds(difference > 0 ? difference : 0);
            };

            updateRemainingTime(); // Вызываем сразу, чтобы не ждать первую итерацию таймера
            const interval = setInterval(updateRemainingTime, 1000);

            return () => clearInterval(interval); // Очищаем таймер при размонтировании

        }else{
            setIsFoundUnblockingPair(false);
        }

    }, [phone, unblockingPairs]);

    // Форматирование в удобный вид
    // Форматирование в удобный вид
    const formatTime = (seconds: number) => {
        const hours = Math.floor(seconds / 3600);
        const minutes = Math.floor((seconds % 3600) / 60);
        const secs = seconds % 60;
        return `${hours > 0 ? `${hours} ч ` : ""}${minutes > 0 ? `${minutes} мин ` : ""}${secs} сек`;
    };




    if (!isOpen) return null;

    return (
        <>
            <div style={{width: scrollbarWidth}} className={styles.scrollbarPlaceholder}></div>

            <div className={styles.backdrop} onClick={closeModal}>


                <div className={styles.modalContainer} onClick={(e) => e.stopPropagation()}>

                    <div className={styles.containerBtnClose}>
                        <button className={styles.closeButton} onClick={closeModal}>&times;</button>
                    </div>

                    <span className={styles.title}>Вход в аккаунт</span>


                    <div className={styles.modalOverlay}>
                        <div className={styles.modal}>


                            {error && <span className={styles.error}>{error}</span>}

                            <form onSubmit={handleSendPhone}>
                                <input
                                    type="tel"
                                    placeholder="Номер телефона"
                                    value={phone}
                                    onChange={(e) => setPhone(e.target.value)}
                                    required
                                    disabled={isSentCode}
                                />
                                {!isSentCode && (
                                    <>
                                        <button type="submit"
                                                disabled={isLoading || !phone.trim() || isFoundUnblockingPair}>
                                            {isLoading ? "Отправка..." : "Отправить код"}
                                        </button>

                                        <button className={styles.btnNavEnterCode} onClick={navEnterCode}>Ввести код
                                        </button>
                                    </>

                                )}

                            </form>

                            {isSentCode && (
                                <form onSubmit={handleVerifyPhoneCode}>
                                    <input
                                        type="text"
                                        placeholder="Введите код"
                                        value={code}
                                        onChange={(e) => setCode(e.target.value)}
                                        required
                                    />
                                    <button type="submit" disabled={isLoading || !code.trim()}>
                                        {isLoading ? "Проверка..." : "Войти"}
                                    </button>

                                    <button
                                        type="button"
                                        disabled={remainingSeconds > 0}
                                        onClick={handleSendPhone}
                                    >
                                        {remainingSeconds > 0 ? formatTime(remainingSeconds): "Повторно отправить"}
                                    </button>

                                    <button className={styles.closeBtn} onClick={() => dispatch(back())}>Назад</button>

                                </form>
                            )}

                            <button className={styles.closeBtn} onClick={closeModal}>Закрыть</button>
                        </div>
                    </div>


                </div>


            </div>

        </>

    );
};

export default LoginModal;

