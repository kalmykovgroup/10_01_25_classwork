import i18next from "i18next";
import { initReactI18next } from "react-i18next";

i18next.use(initReactI18next).init({
    resources: {
        en: {
            translation: {
                errors: {
                    unauthorized: "You are not authorized!",
                    serverError: "Something went wrong. Try again later.",
                },
            },
        },
        ru: {
            translation: {
                errors: {
                    unauthorized: "Вы не авторизованы!",
                    serverError: "Что-то пошло не так. Попробуйте позже.",
                },
            },
        },
    },
    lng: "ru", // Можно сделать динамически через localStorage или настройки пользователя
    fallbackLng: "en",
});

export default i18next;
