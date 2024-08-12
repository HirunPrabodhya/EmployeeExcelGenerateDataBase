using BackEnd.Data;
using BackEnd.Model;
using BackEnd.Service.Implementation;
using BackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region DbConection
builder.Services.AddDbContext<EmployeeWorkFlowDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection"));
});
#endregion
#region dependencyInjection
    builder.Services.AddScoped<IEmployee, EmployeeWorkFlowService>();
#endregion
#region FrontEndBackEndConnection
    builder.Services.AddCors(setup =>
    {
        setup.AddPolicy("default", option =>
        {
            option.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();

        });
    });
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("default");
app.UseAuthorization();

app.MapControllers();

app.Run();
