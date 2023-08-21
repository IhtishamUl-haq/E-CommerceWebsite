using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;
using API.Errors;
using API.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);


// Add services to the container.
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

//string? connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");
//builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddAutoMapper(typeof(MappingProfile));

//builder.Services.Configure<ApiBehaviorOptions>(options => {
//    options.InvalidModelStateResponseFactory = actionContext =>
//    {
//        var errors = actionContext.ModelState
//        .Where(x => x.Value.Errors.Count > 0)
//        .SelectMany(x => x.Value.Errors)
//        .Select(x => x.ErrorMessage).ToArray();

//        var errorResoonse = new ApiValidationErrorResponse
//        {
//            Errors = errors
//        };


//    return new BadRequestObjectResult(errorResoonse);
//    };
//});



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
app.UseCors("CorsPolicy");
app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();











