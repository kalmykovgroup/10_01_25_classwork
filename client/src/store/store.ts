import { configureStore, combineReducers } from '@reduxjs/toolkit';
import { persistStore, persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage'; // Используем localStorage
import productsReducer from './productSpace/productsSlice.ts';
import authReducer from './userSpace/authSlice.ts';
import uiReducer from './uiReducer.ts';
import notificationReducer from './notificationSlice.ts';

// 🔹 Конфигурация persist
const persistConfig = {
    key: 'root',       // Ключ для хранения в localStorage
    storage,           // Где хранить (localStorage)
    whitelist: ['auth', 'ui', 'notifications'], // Какие редюсеры сохранять
};

// 🔹 Комбинированный редюсер (все редюсеры приложения)
const rootReducer = combineReducers({
    products: productsReducer, // ❌ НЕ сохраняем (данные API)
    auth: authReducer,         // ✅ Сохраняем (авторизация)
    ui: uiReducer,             // ✅ Сохраняем (UI настройки)
    notifications: notificationReducer, // ✅ Сохраняем (уведомления)
});

// 🔹 Оборачиваем rootReducer в persistReducer
const persistedReducer = persistReducer(persistConfig, rootReducer);

// 🔹 Создаем store с persistedReducer
export const store = configureStore({
    reducer: persistedReducer,
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
            serializableCheck: false, // Отключаем предупреждение о сериализации
        }),
});

// 🔹 Создаем persistor
export const persistor = persistStore(store);

// 🔹 Типизация Redux (без изменений)
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
