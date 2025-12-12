using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIOMS.Data;

namespace SIOMS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // 1. Total products
            var totalProducts = await _context.Products.CountAsync();

            // 2. Total stock quantity
            var totalStockQty = await _context.Products.SumAsync(p => p.StockQuantity);

            // 3. Total inventory value
            var inventoryValue = await _context.Products
                .SumAsync(p => p.StockQuantity * p.Price);

            // 4. Low stock count
            var lowStockCount = await _context.Products
                .CountAsync(p => p.StockQuantity < p.MinimumStockLevel);

            // 5. Recent stock movements
            var recentMovements = await _context.StockMovements
                .Include(m => m.Product)
                .OrderByDescending(m => m.MovementDate)
                .Take(10)
                .ToListAsync();

            // 6. Top low stock products
            var lowStockProducts = await _context.Products
                .Where(p => p.StockQuantity < p.MinimumStockLevel)
                .OrderBy(p => p.StockQuantity)
                .Take(5)
                .ToListAsync();

            ViewBag.TotalProducts = totalProducts;
            ViewBag.TotalStockQty = totalStockQty;
            ViewBag.InventoryValue = inventoryValue;
            ViewBag.LowStockCount = lowStockCount;
            ViewBag.RecentMovements = recentMovements;
            ViewBag.LowStockProducts = lowStockProducts;

            return View();
        }
    }
}
