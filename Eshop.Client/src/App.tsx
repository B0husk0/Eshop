import { useState } from 'react';
import { Store } from 'lucide-react';
import Categories from './components/Categories';
import Products from './components/Products';
import Toast from './components/Toast';

type Page = 'categories' | 'products';

interface ToastState {
  message: string;
  type: 'success' | 'error';
}

function App() {
  const [currentPage, setCurrentPage] = useState<Page>('products');
  const [toast, setToast] = useState<ToastState | null>(null);

  const showToast = (message: string, type: 'success' | 'error') => {
    setToast({ message, type });
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
              <button
                onClick={() => setCurrentPage('categories')}
                className={`px-4 py-2 rounded-lg font-medium transition-colors ${
                  currentPage === 'categories'
                    ? 'bg-blue-600 text-white'
                    : 'text-gray-700 hover:bg-gray-100'
                }`}
              >
                Categories
              </button>
              <button
                onClick={() => setCurrentPage('products')}
                className={`px-4 py-2 rounded-lg font-medium transition-colors ${
                  currentPage === 'products'
                    ? 'bg-blue-600 text-white'
                    : 'text-gray-700 hover:bg-gray-100'
                }`}
              >
                Products
              </button>
            </div>
          </div>
        </div>
      </nav>

      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        {currentPage === 'categories' ? (
          <Categories />
        ) : (
          <Products onNotify={showToast} />
        )}
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
