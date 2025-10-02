import { useState } from 'react';
import { Routes, Route, Link, Navigate, useLocation } from 'react-router-dom';
import { Store } from 'lucide-react';
import Categories from './components/Categories';
import Products from './components/Products';
import CategoryProducts from './components/CategoryProducts';
import Toast from './components/Toast';

interface ToastState {
  message: string;
  type: 'success' | 'error';
}

function App() {
  const [toast, setToast] = useState<ToastState | null>(null);
  const location = useLocation();

  const showToast = (message: string, type: 'success' | 'error') => {
    setToast({ message, type });
  };

  const isActive = (path: string) => {
    return location.pathname === path || location.pathname.startsWith(path);
  };

  return (
    <div className="min-h-screen bg-gray-50">
      <nav className="bg-white shadow-sm border-b border-gray-200">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex items-center justify-between h-16">
            <div className="flex items-center gap-3">
              <Store className="w-8 h-8 text-blue-600" />
              <span className="text-xl font-bold text-gray-900">Eshop Manager</span>
            </div>

            <div className="flex gap-2">
              <Link
                to="/categories"
                className={`px-4 py-2 rounded-lg font-medium transition-colors ${
                  isActive('/categories')
                    ? 'bg-blue-600 text-white'
                    : 'text-gray-700 hover:bg-gray-100'
                }`}
              >
                Categories
              </Link>
              <Link
                to="/products"
                className={`px-4 py-2 rounded-lg font-medium transition-colors ${
                  isActive('/products')
                    ? 'bg-blue-600 text-white'
                    : 'text-gray-700 hover:bg-gray-100'
                }`}
              >
                Products
              </Link>
            </div>
          </div>
        </div>
      </nav>

      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <Routes>
          <Route path="/" element={<Navigate to="/products" replace />} />
          <Route path="/products" element={<Products onNotify={showToast} />} />
          <Route path="/categories" element={<Categories />} />
          <Route path="/category/:id" element={<CategoryProducts onNotify={showToast} />} />
        </Routes>
      </main>

      {toast && (
        <Toast
          message={toast.message}
          type={toast.type}
          onClose={() => setToast(null)}
        />
      )}
    </div>
  );
}

export default App;
