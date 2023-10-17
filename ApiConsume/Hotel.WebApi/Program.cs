using Hotel.BusinessLayer.Abstract;
using Hotel.BusinessLayer.Concreate;
using Hotel.BusinessLayer.Extensitions;
using Hotel.DataAccessLayer;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{// Burada þifrtede olmasý gereken büyük yazý küçük yazý gibi zorunlululalrrý true ve false olarak gerekliliðini ifade ediyoruz. 
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;

})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.LoadServicesLayerExtensions();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program)); //AutoMapper için eklenen alandýr
builder.Services.AddCors(option =>// api iþlemlerini yapabilmek için Cors metodu eklendi
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
app.UseCors("HotelsApiCors");// Cors iþlemi için
app.UseAuthorization();

app.MapControllers();

app.Run();
