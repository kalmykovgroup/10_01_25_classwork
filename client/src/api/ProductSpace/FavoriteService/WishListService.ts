import apiClient from "../../clientApi.ts";
import {AddWishListProductResponse} from "./Responses/AddWishListProductResponse.ts";

// ✅ Запрос на добавление/удаление товара из избранного
export async function toggleFavorite(productId: string): Promise<AddWishListProductResponse> {
    try {
        const response = await apiClient.post(`/product/add-to-wish-list`, productId);
        return response.data;

    } catch (error) {
        console.error("Ошибка при обновлении избранного:", error);
        throw error;
    }
}