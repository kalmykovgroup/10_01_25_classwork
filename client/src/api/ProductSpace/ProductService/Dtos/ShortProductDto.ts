export interface ShortProductDto {
    id: string;
    url: string;
    name: string;
    price: number;
    originalPrice: number | null;
    discountPercentage: number | null;
    isDiscount: boolean;
}

