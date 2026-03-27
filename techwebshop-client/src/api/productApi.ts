
import type { Product } from "../types";

const BASE_URL = "http://localhost:5083/api";

export const getProducts = async (): Promise<Product[]> => {
    const response = await fetch(`${BASE_URL}/product`);
    if(!response.ok) throw new Error("Failed to fetch products");
    return response.json();
}

export const getProductById = async (id: string): Promise<Product> => {
    const response = await fetch(`${BASE_URL}/product/${id}`);
    if(!response.ok) throw new Error(`Failed to fetch product with id: ${id}`);
    return response.json();
}

export const filterProducts = async (query: string): Promise<Product[]> => {
    const response = await fetch(`${BASE_URL}/product/search?query=${encodeURIComponent(query)}`);
    if(!response.ok) throw new Error("No products matches search input...");
    return response.json();
}

