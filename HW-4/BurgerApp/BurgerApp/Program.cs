using BurgerApp.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registering Dependency Injection without a helper
//builder.Services.AddTransient<IOrderService, OrderService>();
//builder.Services.AddTransient<IRepository<Order>, OrderRepository>();

var connectionString = builder.Configuration.GetConnectionString("BurgerAppCS");

builder.Services.InjectServices();
builder.Services.InjectRepositories();
builder.Services.InjectDbContext(connectionString);

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

app.Run();
