


//using Core.Interfaces;
//using Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//string? connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");
//builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(connectionString));

//// Get an instance of the ILoggerFactory
// var app = builder.Build();
//var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

//using (var scope = app.Services.CreateScope())
//{
//    var service = scope.ServiceProvider;
//    try
//    {
//        var dbContext = service.GetRequiredService<StoreContext>();

//        // Apply pending migrations and create the database if not exists
//        dbContext.Database.Migrate();
//        StoreContextSeed.SeedAsync(dbContext, loggerFactory);
//    }
//    catch (Exception e)
//    {
//        var log = loggerFactory.CreateLogger<Program>();
//        log.LogError(e, "Error occurred in Migration");
//    }
//}
////// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();























using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using API.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

string? connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(MappingProfile));


//var serviceProvider = new ServiceCollection()
//                .AddDbContext<StoreContext>(options =>
//                    options.UseSqlServer(connectionString))
//                .BuildServiceProvider();

//using (var scope = serviceProvider.CreateScope())
//{
//    var service = scope.ServiceProvider;
//    //var loggerFactory = service.GetRequiredService<ILoggerFactory>();
//    try
//    {
//        var dbContext = service.GetRequiredService<StoreContext>();

//        // Apply pending migrations and create the database if not exists
//        dbContext.Database.Migrate();
//        StoreContextSeed.SeedAsync(dbContext, null);
//    }
//    catch (Exception e)
//    {
//        //var log = loggerFactory.CreateLogger<Program>();
//        //log.LogError(e, "Error ocurred in Migration");
//    }


//    // You can also add data seeding logic here if needed
//    // SeedData.Initialize(dbContext);
//}






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Seed the database within a service scope
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    try
    {
        var dbContext = service.GetRequiredService<StoreContext>();

        // Apply pending migrations and create the database if not exists
        dbContext.Database.Migrate();

        // Seed the data
        StoreContextSeed.SeedAsync(dbContext, null).Wait(); // Wait for the seed operation to complete
    }
    catch (Exception e)
    {
        var log = service.GetRequiredService<ILogger<Program>>();
        log.LogError(e, "Error occurred in Migration");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();











