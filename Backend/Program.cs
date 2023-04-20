using Backend;
using Backend.Data;
using Backend.Models;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeContext>(options => 
    options.UseSqlServer("Server=localhost;User ID=sa;Password=sa;database=Ejercicio;TrustServerCertificate=true;")
    );

var app = builder.Build();

app.MapGet("/api/emp", async (IEmployeeRepository empRepo)=>
            {
                var emp = await empRepo.GetAll();
                return Results.Ok(emp);
            });

            app.MapPost("/api/emp/save", async (IEmployeeRepository empRepo,Employee emp) =>
            {
                var result = await empRepo.Add(emp);
                if (result)
                    return Results.Ok("Saved successfully");
                return Results.Problem();
            });

            app.MapPut("/api/person", async (IEmployeeRepository empRepo, Employee emp) =>
            {
                var result = await empRepo.Update(emp);
                if (result)
                    return Results.Ok("Updated successfully");
                return Results.Problem();
            });

            app.MapGet("/api/person/{id}", async (int id,IEmployeeRepository empRepo) =>
            {
                var emp = await empRepo.GetById(id);
                if (emp is null)
                    return Results.NotFound();
                return Results.Ok(emp);
            });

            app.MapGet("/api/person/{name}", async (string name,IEmployeeRepository empRepo) =>
            {
                var emp = await empRepo.GetByName(name);
                if (emp is null)
                    return Results.NotFound();
                return Results.Ok(emp);
            });

            app.MapDelete("/api/person/{id}", async (IEmployeeRepository empRepo, int id) =>
            {
                var result = await empRepo.Delete(id);
                if (result)
                    return Results.Ok("Deleted successfully");
                return Results.Problem();
            });

app.Run();
