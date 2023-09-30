using Hotel.BusinessLayer.Abstract;
using Hotel.BusinessLayer.Concreate;
using Hotel.BusinessLayer.Extensitions;
using Hotel.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.LoadServicesLayerExtensions();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program)); //AutoMapper i�in eklenen aland�r
builder.Services.AddCors(option =>// api i�lemlerini yapabilmek i�in Cors metodu eklendi
{
    option.AddPolicy("HotelsApiCors", opt =>
    {
        opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
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
app.UseCors("HotelsApiCors");// Cors i�lemi i�in
app.UseAuthorization();

app.MapControllers();

app.Run();
