using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Model;
using WebApplicationApi.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICarRepository, CarRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagger();


app.MapGet("/v1/car", ([FromServices] ICarRepository repository) =>
{
    return repository.GetCars();
});

app.MapPost("/v1/car/insert", ([FromServices] ICarRepository repository, Car car) =>
{

    var result = repository.InsertCar(car);

    return (result ? Results.Ok($"carro {car.Model} inserido com sucesso")
    :
    Results.BadRequest("Nâo foi possivel inserir o carro"));
});

app.MapPut("/v1/car/color", ([FromServices] ICarRepository repository, int Id, string Color) =>
{
    var result = repository.UpdateCarColor(Id, Color);

    return (result ? Results.Ok($"cor alterada com sucesso")
    :
    Results.BadRequest("Nâo foi possivel alterar a cor do carro"));
});

app.MapDelete("/v1/car/delete", ([FromServices] ICarRepository repository, int Id) =>
{
    var result = repository.DeleteCar(Id);

    return (result ? Results.Ok($"carro deletado sucesso")
    :
    Results.BadRequest("nao foi possivel carro"));
});

app.Run();
}
