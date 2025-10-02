import { useState, useEffect } from 'react';
import { ShoppingCart, Plus, RefreshCw } from 'lucide-react';
import { api, Product } from '../services/api';
import AddProductForm from './AddProductForm';
import UpdateStockForm from './UpdateStockForm';

interface ProductsProps {
  onNotify: (message: string, type: 'success' | 'error') => void;
}

export default function Products({ onNotify }: ProductsProps) {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [showAddForm, setShowAddForm] = useState(false);
  const [selectedProduct, setSelectedProduct] = useState<Product | null>(null);

  useEffect(() => {
    loadProducts();
  }, []);

  const loadProducts = async () => {
    try {
      setLoading(true);
      setError(null);
      const data = await api.getProducts();
      setProducts(data);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to load products');
    } finally {
      setLoading(false);
    }
  };

  const handleProductAdded = () => {
    setShowAddForm(false);
    loadProducts();
    onNotify('Product added successfully!', 'success');
  };

  const handleStockUpdated = () => {
    setSelectedProduct(null);
    loadProducts();
    onNotify('Stock updated successfully!', 'success');
  };

  if (loading) {
    return (
      <div className="flex justify-center items-center py-12">
        <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-blue-600"></div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="bg-red-50 border border-red-200 rounded-lg p-4">
        <p className="text-red-800 font-medium">Error: {error}</p>
        <button
          onClick={loadProducts}
          className="mt-2 text-sm text-red-600 hover:text-red-800 underline"
        >
          Try again
        </button>
      </div>
    );
  }

  return (
    <div>
      <div className="flex items-center justify-between mb-6">
        <div className="flex items-center gap-3">
          <ShoppingCart className="w-8 h-8 text-blue-600" />
          <h1 className="text-3xl font-bold text-gray-900">Products</h1>
        </div>
        <button
          onClick={() => setShowAddForm(true)}
          className="flex items-center gap-2 bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors"
        >
          <Plus className="w-5 h-5" />
          Add Product
        </button>
      </div>

      {showAddForm && (
        <AddProductForm
          onClose={() => setShowAddForm(false)}
          onSuccess={handleProductAdded}
          onError={(msg) => onNotify(msg, 'error')}
        />
      )}

      {selectedProduct && (
        <UpdateStockForm
          product={selectedProduct}
          onClose={() => setSelectedProduct(null)}
          onSuccess={handleStockUpdated}
          onError={(msg) => onNotify(msg, 'error')}
        />
      )}

      {products.length === 0 ? (
        <div className="text-center py-12 bg-gray-50 rounded-lg">
          <p className="text-gray-600">No products found</p>
        </div>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
          {products.map((product) => (
            <div
              key={product.id}
              className="bg-white rounded-lg shadow-sm border border-gray-200 p-5 hover:shadow-md transition-shadow"
            >
              <div className="flex justify-between items-start mb-3">
                <h3 className="text-lg font-semibold text-gray-900">
                  {product.name}
                </h3>
                <span className="text-xl font-bold text-blue-600">
                  ${product.price.toFixed(2)}
                </span>
              </div>
              <img
  src={product.imageUrl}
  alt={product.name}
  className="w-full h-40 object-contain mb-3"
/>


              <p className="text-gray-600 text-sm mb-4 line-clamp-2">
                {product.description}
              </p>

              <div className="flex items-center justify-between pt-3 border-t border-gray-100">
                <div>
                  <p className="text-xs text-gray-500">Stock</p>
                  <p className={`text-sm font-semibold ${
                    product.quantity > 10 ? 'text-green-600' :
                    product.quantity > 0 ? 'text-yellow-600' :
                    'text-red-600'
                  }`}>
                    {product.quantity} units
                  </p>
                </div>

                <button
                  onClick={() => setSelectedProduct(product)}
                  className="flex items-center gap-1 text-sm text-blue-600 hover:text-blue-800 font-medium"
                >
                  <RefreshCw className="w-4 h-4" />
                  Update Stock
                </button>
              </div>

              {product.category && (
                <div className="mt-3 pt-3 border-t border-gray-100">
                  <p className="text-xs text-gray-500">Category</p>
                  <p className="text-sm text-gray-700">{product.category.name}</p>
                </div>
              )}
            </div>
          ))}
        </div>
      )}
    </div>
  );
}
