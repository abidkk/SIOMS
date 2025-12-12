using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIOMS.Data;
using SIOMS.Models;
using SIOMS.Models.Enums;
using SIOMS.Services;

namespace SIOMS.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly StockAlertService _alertService;


        //public SalesOrderController(AppDbContext context)
        //{
        //    _context = context;
        //}
        public SalesOrderController(AppDbContext context, StockAlertService alertService)
        {
            _context = context;
            _alertService = alertService;
        }



        public async Task<IActionResult> Index()
        {
            var orders = await _context.SalesOrders
                .Include(o => o.Customer)
                .Include(o => o.Items)
                .ToListAsync();

            return View(orders);
        }

        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesOrder order, List<SalesOrderItem> items)
        {
            if (items == null || !items.Any())
            {
                ModelState.AddModelError("", "Please add at least one product.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Customers = _context.Customers.ToList();
                ViewBag.Products = _context.Products.ToList();
                return View(order);
            }

            // Validate stock levels
            foreach (var item in items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product.StockQuantity < item.Quantity)
                {
                    ModelState.AddModelError("", $"Not enough stock for {product.Name}. Available: {product.StockQuantity}");
                    ViewBag.Customers = _context.Customers.ToList();
                    ViewBag.Products = _context.Products.ToList();
                    return View(order);
                }
            }

            order.TotalAmount = items.Sum(i => i.LineTotal);
            order.Items = items;

            _context.SalesOrders.Add(order);

            // Deduct stock
            foreach (var item in items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                //product.StockQuantity -= item.Quantity;
                var oldStock = product.StockQuantity;

                product.StockQuantity -= item.Quantity;
                _alertService.CheckStock(product);


                // Log stock movement
                var movement = new StockMovement
                {
                    ProductId = item.ProductId,
                    MovementType = MovementType.StockOut,
                    QuantityChanged = -item.Quantity,
                    FinalStock = product.StockQuantity,
                    ReferenceNumber = $"SO-{order.Id}"
                };

                _context.StockMovements.Add(movement);

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.SalesOrders
                .Include(o => o.Customer)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            return View(order);
        }
    }
}
