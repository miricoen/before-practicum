using AutoMapper;
using Mng.API.Config;
using Mng.Core;
using Mng.Core.Repositories;
using Mng.Core.Services;
using Mng.Data;
using Mng.Data.Repositories;
using Mng.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//    options.JsonSerializerOptions.WriteIndented = true;
//});
//builder.Services.AddControllers();


builder.Services.ConfigureServices();
 // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddScoped<IRolesForEmployeeService, RolesForEmployeeService>();
//builder.Services.AddScoped<IRolesForEmployeeRepository, RolesForEmployeeRepository>();
//builder.Services.ConfigureServices();
//var mappingConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new Mapping());
//});

//IMapper mapper = mappingConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);
builder.Services.AddDbContext<DataContext>();

var policy = "policy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(policy);

app.MapControllers();

app.Run();
