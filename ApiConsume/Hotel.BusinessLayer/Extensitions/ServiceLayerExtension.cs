using Hotel.BusinessLayer.Abstract;
using Hotel.BusinessLayer.Concreate;
using Hotel.EntitiyLayer.Concreate;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Hotel.BusinessLayer.Extensitions
{
	public static class ServiceLayerExtension
	{
		public static IServiceCollection LoadServicesLayerExtensions(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();

         
            services.AddTransient(typeof(IService<>), typeof(Service<>));
			
			services.AddScoped<IStuffService, StuffService>();
			services.AddScoped<IRoomService, RoomService>();
			services.AddScoped<IServiceService, ServiceServices>();
			services.AddScoped<ISliderService, SliderService>();
			services.AddScoped<ISubscribeService, SubscribeService>();
			services.AddScoped<ITestimonialService, TestimonialService>();
			services.AddScoped<IAboutService, AboutService>();
			services.AddScoped<IBookingService, BookingService>();
			services.AddScoped<IContactService, ContactService>();
			services.AddScoped<ISenderMessageService, SenderMessageService>();
			services.AddScoped<ICategoryMessageService, CategoryMessageService>();
			
           
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddAutoMapper(assembly);


            //services.AddControllersWithViews().AddFluentValidation(opt =>
            //{
            //	opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
            //	opt.DisableDataAnnotationsValidation = true;
            //	opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");

            //});
            // Fluent validation için eklenen servic kodlarıdır. 
            return services;
		}
	}
}
