using Hotel.BusinessLayer.Abstract;
using Hotel.BusinessLayer.Concreate;
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
			//services.AddTransient<IUserService, UserService>();// servis için eklendi
			//services.AddScoped<IImageHelper, ImageHelper>();
			//services.AddTransient<IDashboardService, DashboardService>();

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
