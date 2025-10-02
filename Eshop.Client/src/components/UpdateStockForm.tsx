import { useState } from 'react';
import { X } from 'lucide-react';
import { api, Product } from '../services/api';

interface UpdateStockFormProps {
  product: Product;
  onClose: () => void;
  onSuccess: () => void;
  onError: (message: string) => void;
}

export default function UpdateStockForm({ product, onClose, onSuccess, onError }: UpdateStockFormProps) {
  const [quantity, setQuantity] = useState(product.quantity);
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (quantity < 0) {
      onError('Quantity cannot be negative');
      return;
    }

    try {
      setLoading(true);
      await api.updateStock(product.id, quantity);
      onSuccess();
    } catch (err) {
      onError(err instanceof Error ? err.message : 'Failed to update stock');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center p-4 z-50">
      <div className="bg-white rounded-lg shadow-xl max-w-md w-full p-6">
        <div className="flex items-center justify-between mb-4">
          <h2 className="text-2xl font-bold text-gray-900">Update Stock</h2>
          <button
            onClick={onClose}
            className="text-gray-400 hover:text-gray-600"
          >
            <X className="w-6 h-6" />
          </button>
        </div>

        <div className="bg-gray-50 rounded-lg p-4 mb-6">
          <p className="text-sm text-gray-600 mb-1">Product</p>
          <p className="font-semibold text-gray-900">{product.name}</p>
          <p className="text-sm text-gray-600 mt-2">Current Stock</p>
          <p className="text-lg font-bold text-blue-600">{product.quantity} units</p>
        </div>

        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">
              New Quantity
            </label>
            <input
              type="number"
              min="0"
              value={quantity}
              onChange={(e) => setQuantity(parseInt(e.target.value) || 0)}
              className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent text-lg"
              required
              autoFocus
            />
            <p className="text-xs text-gray-500 mt-1">
              This will update the stock via RabbitMQ (v2 API)
            </p>
          </div>

          <div className="flex gap-3 pt-4">
            <button
              type="button"
              onClick={onClose}
              className="flex-1 px-4 py-2 border border-gray-300 rounded-lg text-gray-700 hover:bg-gray-50 transition-colors"
            >
              Cancel
            </button>
            <button
              type="submit"
              disabled={loading}
              className="flex-1 px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors disabled:bg-blue-400 disabled:cursor-not-allowed"
            >
              {loading ? 'Updating...' : 'Update Stock'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
