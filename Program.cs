using wt_lab6_6minimalapi_glebko.Data;
using wt_lab6_6minimalapi_glebko.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "всё ок");
//список + Фильтрация (search)
app.MapGet("/api/flights", (string? search) =>
{
    var flights = FlightStore.Flights.AsEnumerable();

    if (!string.IsNullOrWhiteSpace(search))
    {
        // Ищем совпадения по городам (без учета регистра)
        flights = flights.Where(x => x.gorod_vilet.Contains(search, StringComparison.OrdinalIgnoreCase)
                                  || x.gorod_prilet.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
    return Results.Ok(flights);
});

// номер рейса (ID) + 404 если нет
app.MapGet("/api/flights/{id}", (int id) =>
{
    var flight = FlightStore.Flights.FirstOrDefault(x => x.nomer_reisa == id);
    if (flight == null)
        return Results.NotFound();

    return Results.Ok(flight);
});

app.MapPost("/api/flights", (Flight flight) =>
{
    // Защита от некорректных данных
    if (string.IsNullOrWhiteSpace(flight.gorod_vilet))
        return Results.BadRequest("Укажите город вылета");

    // Автоматическая генерация ID
    flight.nomer_reisa = FlightStore.Flights.Count == 0 ? 1 : FlightStore.Flights.Max(x => x.nomer_reisa) + 1;

    FlightStore.Flights.Add(flight);

    return Results.Created($"/api/flights/{flight.nomer_reisa}", flight);
});

app.MapPut("/api/flights/{id}", (int id, Flight updatedFlight) =>
{
    var flight = FlightStore.Flights.FirstOrDefault(x => x.nomer_reisa == id);
    if (flight == null)
        return Results.NotFound();

    // Обновляем поля
    flight.gorod_vilet = updatedFlight.gorod_vilet;
    flight.gorod_prilet = updatedFlight.gorod_prilet;
    flight.vremya_vileta = updatedFlight.vremya_vileta;
    flight.cena = updatedFlight.cena;
    flight.mesta = updatedFlight.mesta;
    flight.dostupno = updatedFlight.dostupno;

    return Results.Ok(flight);
});

app.MapDelete("/api/flights/{id}", (int id) =>
{
    var flight = FlightStore.Flights.FirstOrDefault(x => x.nomer_reisa == id);
    if (flight == null)
        return Results.NotFound();

    FlightStore.Flights.Remove(flight);

    return Results.NoContent();
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");