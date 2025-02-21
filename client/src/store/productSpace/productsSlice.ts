import {createSlice, createAsyncThunk, PayloadAction} from "@reduxjs/toolkit";
import { fetchProducts } from "../../api/ProductSpace/ProductService/ProductService.ts";
import {toggleFavorite} from "../../api/ProductSpace/FavoriteService/FavoriteService.ts";
import {
    AddWishListProductResponse
} from "../../api/ProductSpace/FavoriteService/Responses/AddWishListProductResponse.ts";
import {ShortProductDtoUiExtended} from "../../api/ProductSpace/ProductService/UI/ShortProductDtoUiExtended.ts";
import {ProductPagedResult} from "../../api/ProductSpace/ProductService/Responses/ProductPagedResult.ts";
import {store} from "../store.ts";
import {addNotification} from "../notificationSlice.ts";


interface ProductsState {
    items: ShortProductDtoUiExtended[];
    page: number;
    totalPages: number;
    loading: boolean;
    search: string;
    categoryId?: string;
}

const initialState: ProductsState = {
    items: [],
    page: 1,
    totalPages: 1,
    loading: false,
    search: "",
    categoryId: undefined,

};

// Запрос списка товаров с пагинацией и фильтрацией
export const fetchProductsThunk = createAsyncThunk<
    ProductPagedResult<ShortProductDtoUiExtended>,
    { page: number; search?: string; categoryId?: string },
    { rejectValue: string }
>(
    "products/fetchProducts",
    async ({ page, search, categoryId }, { rejectWithValue }) => {
        try {
            return await fetchProducts({ page, search, categoryId });
        } catch (err) {
            return rejectWithValue("Error loading products");
        }
    }
);


// ✅ Новый thunk для работы с избранным
export const toggleFavoriteThunk = createAsyncThunk<AddWishListProductResponse, string>(
    "products/toggleFavorite",
    async (productId) => {
         return await toggleFavorite(productId);
    }
);

const productsSlice = createSlice({
    name: "products",
    initialState,
    reducers: {
        setSearch: (state, action: PayloadAction<string>) => {
            state.search = action.payload;
            state.page = 1; // Сброс страницы при новом поисковом запросе
        },
        setPage: (state, action: PayloadAction<number>) => {
            state.page = action.payload;
        },
        setCategory: (state, action: PayloadAction<string | undefined>) => {
            state.categoryId = action.payload;
            state.page = 1;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchProductsThunk.pending, (state) => {
                state.loading = true;
              //  state.error = null;

            })
            .addCase(fetchProductsThunk.fulfilled, (state, action) => {
                state.loading = false;
                state.totalPages = action.payload.totalPages; // Обновляем кол-во страниц
                state.page = action.payload.page; // Обновляем текущую страницу

                const existingIds = new Set(state.items.map((p) => p.id));
                const newItems = action.payload.items.filter((p) => !existingIds.has(p.id));

                state.items = [...state.items, ...newItems];
            })
            .addCase(fetchProductsThunk.rejected, (state, action) => {
                state.loading = false;
             //   state.error = action.error.message ?? "Ошибка загрузки товаров";
                store.dispatch(addNotification({ message: action.error.message ?? "Error loading products", type: "error" }));

            })


            // ✅ Обрабатываем успешное добавление в избранное
            .addCase(toggleFavoriteThunk.fulfilled, (state, action) => {

                if(action.payload.success){
                    const product = state.items.find((p) => p.id === action.payload.productId);

                    if (product) {
                        product.isFavorite = action.payload.isFavorite;
                    }
                }else{
                    store.dispatch(addNotification({ message: action.payload.error ?? "Error", type: "error" }));
                }
            })

            .addCase(toggleFavoriteThunk.rejected, (_state, action) => {
                store.dispatch(addNotification({ message: action.error.message ?? "Error", type: "error" }));
            });

    },
});
export const {  setSearch, setPage, setCategory } = productsSlice.actions;
export default productsSlice.reducer;
