using SIOMS.Models;

namespace SIOMS.Services
{
    public class StockAlertService
    {
        // 1️⃣ Delegate definition
        public delegate void LowStockEventHandler(Product product);

        // 2️⃣ Event definition
        public event LowStockEventHandler OnLowStock;

        // 3️⃣ Method that triggers event
        public void CheckStock(Product product)
        {
            if (product.StockQuantity < product.MinimumStockLevel)
            {
                OnLowStock?.Invoke(product);
            }
        }
    }
}
