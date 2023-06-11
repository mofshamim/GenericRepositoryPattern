
using GenericRepositoryPattern.DataAccessLayer;
using GenericRepositoryPattern.DataContext;
using GenericRepositoryPattern.Domain.Entities;
using GenericRepositoryPattern.ServiceLayer;
using GenericRepositoryPattern.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(@"Server=SHAMIM\SQLEXPRESS;Database=EmployeeDb;User Id=sa;Password=sa1234;TrustServerCertificate=True");
});


//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbconnection")));

builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(@"Server=SHAMIM\SQLEXPRESS;Database=EmployeeDb;User Id=sa;Password=sa1234;TrustServerCertificate=True");
//});

//builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));