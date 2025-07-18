using Backend.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// get all burger places
app.MapGet("/burgerplace", () => BurgerPlaceDataStore.Database);
// get burgerplace by id
app.MapGet("/burgerplace/{id}", (int id) =>
{
    BurgerPlace? place = BurgerPlaceDataStore.Database.FirstOrDefault(f => f.Id == id);
    return place switch
    {
        null => Results.NotFound(),
        _ => Results.Ok(place)
    };
});
// new
app.MapPost("/burgerplace", ([FromBody] BurgerPlace model) => {
    model.Votes = 0;

    int id = (int?)(
        from d in BurgerPlaceDataStore.Database
        orderby d.Id descending
        select d.Id
    ).FirstOrDefault() ?? 0;

    model.Id = id + 1;
    BurgerPlaceDataStore.Database.Add(model);

    return model;
});
// update
app.MapPut("/burgerplace/{id}", (int id, [FromBody] BurgerPlace model) =>
{
    BurgerPlace? place = BurgerPlaceDataStore.Database.FirstOrDefault(f => f.Id == id);
    if (place != null)
    {
        place.Name = model.Name;
    }
    return place;
});
app.MapDelete("/burgerplace/{id}", (int id) =>
{
    BurgerPlace? place = BurgerPlaceDataStore.Database.FirstOrDefault(f => f.Id == id);
    if (place != null)
    {
        BurgerPlaceDataStore.Database.Remove(place);
    }
});

// get all votes
app.MapGet("/vote", () => BurgerPlaceDataStore.Database);
// add 1 vote
app.MapPost("/vote/{id}", (int id) =>
{
    BurgerPlace? place = BurgerPlaceDataStore.Database.FirstOrDefault(f => f.Id == id);
    if (place != null)
    {
        place.Votes++;
    }
    return place;
});
// remove 1 vote
app.MapDelete("/vote/{id}", (int id) =>
{
    BurgerPlace? place = BurgerPlaceDataStore.Database.FirstOrDefault(f => f.Id == id);
    if (place != null)
    {
        place.Votes--;
    }
    return place;
});


app.Run();
