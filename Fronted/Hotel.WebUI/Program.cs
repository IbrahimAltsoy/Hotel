using FluentValidation;
using FluentValidation.AspNetCore;
using Hotel.BusinessLayer.Abstract;
using Hotel.BusinessLayer.Concreate;
using Hotel.DataAccessLayer;
using Hotel.EntitiyLayer.Concreate;
using Hotel.WebUI.Dtos.GuestDto;
using Hotel.WebUI.Validation.GuestValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using NToastNotify;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();//Api projesi
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 3000

    })
    .AddFluentValidation();

    
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IValidator<CreateGuestDto>, Create_Guest_Validation>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAutoMapper(typeof(Program)); //AutoMapper için eklenen alandýr
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));


});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan= TimeSpan.FromDays(1);
    options.LoginPath = "/Login/Index/";
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Default/ErrorNumber", "?code={0}");
app.UseNToastNotify();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
