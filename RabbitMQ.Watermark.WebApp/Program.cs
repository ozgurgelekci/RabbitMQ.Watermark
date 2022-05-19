using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Watermark.WebApp.DataAccess;
using RabbitMQ.Watermark.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase(databaseName: "productDb");
});

builder.Services.AddSingleton(opt =>

    new ConnectionFactory() { Uri = new Uri(builder.Configuration.GetConnectionString("RabbitMQ")) }
);

builder.Services.AddSingleton<RabbitMQClientService>();
builder.Services.AddSingleton<RabbitMQPublisher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
