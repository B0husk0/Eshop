const API_BASE_URL = 'https://api-a-efhtd5d9bbcwc5g3.westeurope-01.azurewebsites.net';

export interface Category {
  id: number;
  name: string;
  description: string;
  imageUrl?: string;
  products?: Product[]; 
}

export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  quantity: number;
  imageUrl: string;
  categoryId: number;
  category?: Category;
}

export interface CreateProductDto {
  name: string;
  description: string;
  price: number;
  quantity: number;
  imageUrl: string;
  categoryId: number;
}

export interface UpdateStockDto {
  quantity: number;
}

export const api = {
  getCategories: async (): Promise<Category[]> => {
    const response = await fetch(`${API_BASE_URL}/api/v1/Categories`);
    if (!response.ok) {
      throw new Error(`Failed to fetch categories: ${response.statusText}`);
    }
    return response.json();
  },

  getCategory: async (id: number): Promise<Category> => {
    const response = await fetch(`${API_BASE_URL}/api/v1/Categories/${id}`);
    if (!response.ok) {
      throw new Error(`Failed to fetch category: ${response.statusText}`);
    }
    return response.json();
  },

  getProducts: async (): Promise<Product[]> => {
    const response = await fetch(`${API_BASE_URL}/api/v1/Products`);
    if (!response.ok) {
      throw new Error(`Failed to fetch products: ${response.statusText}`);
    }
    return response.json();
  },

  createProduct: async (product: CreateProductDto): Promise<Product> => {
    const response = await fetch(`${API_BASE_URL}/api/v1/Products`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(product),
    });
    if (!response.ok) {
      const error = await response.text();
      throw new Error(error || `Failed to create product: ${response.statusText}`);
    }
    return response.json();
  },

  updateStock: async (id: number, quantity: number): Promise<void> => {
    const response = await fetch(`${API_BASE_URL}/api/v2/ProductsV/rabbit/${id}/stock`, {
      method: 'PATCH',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ quantity }),
    });
    if (!response.ok) {
      const error = await response.text();
      throw new Error(error || `Failed to update stock: ${response.statusText}`);
    }
  },
};
