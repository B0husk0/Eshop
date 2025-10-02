import { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import { ShoppingCart, ArrowLeft } from 'lucide-react';
import { api, Product, Category } from '../services/api';

interface CategoryProductsProps {
  onNotify: (message: string, type: 'success' | 'error') => void;
}

export default function CategoryProducts({ onNotify }: CategoryProductsProps) {
  const { id } = useParams<{ id: string }>();
  const [category, setCategory] = useState<Category | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    loadCategory();
  }, [id]);

  const loadCategory = async () => {
    if (!id) return;
    try {
      setLoading(true);
      setError(null);

      const categoryId = parseInt(id);
      const data = await api.getCategory(categoryId); // 👈 použijeme nový endpoint
      setCategory(data);

    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to load category');
      onNotify('Failed to load category', 'error');
    } finally {
      setLoading(false);
    }
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
          onClick={loadCategory}
          className="mt-2 text-sm text-red-600 hover:text-red-800 underline"
        >
          Try again
        </button>
      </div>
    );
  }

  const products: Product[] = category?.products || [];

  return (
    <div>
      <div className="flex items-center gap-4 mb-6">
        <Link
          to="/categories"
          className="text-gray-600 hover:text-gray-900 transition-colors"
        >
          <ArrowLeft className="w-6 h-6" />
        </Link>
        <div className="flex items-center gap-3">
          <ShoppingCart className="w-8 h-8 text-blue-600" />
          <h1 className="text-3xl font-bold text-gray-900">
            {category?.name} Products
          </h1>
        </div>
      </div>

      {products.length === 0 ? (
        <div className="text-center py-12 bg-gray-50 rounded-lg">
          <p className="text-gray-600">No products found in this category</p>
          <Link
            to="/categories"
            className="mt-4 inline-block text-blue-600 hover:text-blue-800 underline"
          >
            Back to categories
          </Link>
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
                  <p
                    className={`text-sm font-semibold ${
                      product.quantity > 10
                        ? 'text-green-600'
                        : product.quantity > 0
                        ? 'text-yellow-600'
                        : 'text-red-600'
                    }`}
                  >
                    {product.quantity} units
                  </p>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}
