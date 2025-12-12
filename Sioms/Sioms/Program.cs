using Microsoft.EntityFrameworkCore;
using SIOMS.Data;
using SIOMS.Services;
using SIOMS.Helpers;  // ? add at top of file


var builder = WebApplication.CreateBuilder(args);


// ** updated 1

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// **




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<StockAlertService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var alertService = app.Services.GetRequiredService<StockAlertService>();

alertService.OnLowStock += (product) =>
{
    Console.WriteLine($"LOW STOCK ALERT: {product.Name} is below minimum level!");
};


alertService.OnLowStock += (product) =>
{
    string msg = $"? LOW STOCK: {product.Name} (Qty: {product.StockQuantity}) < Minimum ({product.MinimumStockLevel})";

    // Add to global alert store
    AlertStore.Add(msg);

    // Console output (for debugging)
    Console.WriteLine(msg);
};


app.Run();
