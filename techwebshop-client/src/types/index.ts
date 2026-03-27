export interface Product {
    id: string;
    name: string;
    description: string;
    price: number;
    categoryId: string;
}

export interface ProductCategory {
    id: string;
    name: string;
    description: string;
}

export interface Customer {
    id: string;
    firstName: string;
    lastName: string;
    email: string;
}